using DotNetEnv.Configuration;
using Marten;
using Marten.Events.Daemon.Resiliency;
using Microsoft.AspNetCore.Http.Json;
using MyFreelanceGigs;
using Oakton;
using Weasel.Core;

//DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterAllFeatures();
builder.Configuration.AddConfiguration(
    new ConfigurationBuilder().AddDotNetEnv().Build()
);

builder.Services.AddMarten(opts =>
    {
        var cs = builder.Configuration.GetConnectionString("MartenCS");
        if (cs is null)
            throw new ArgumentNullException(nameof(cs), "Connection string must not be null");
        opts.Connection(cs);

        if (builder.Environment.IsDevelopment())
        {
            opts.AutoCreateSchemaObjects = AutoCreate.All;
        }
        
    }).InitializeWith()
    .AddAsyncDaemon(DaemonMode.Solo);

builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.PropertyNamingPolicy = null)
    .Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Host.ApplyOaktonExtensions();

var app = builder.Build();

app.UseStaticFiles();

GlobalErrorHandler.Register(app);

foreach (var apiBuilder in app.Services.GetService<IEnumerable<IApiBuilder>>()!)
{
    apiBuilder.BuildApi(app);
}

app.MapFallbackToFile("index.html");

await app.RunOaktonCommands(args);

