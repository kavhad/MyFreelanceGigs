using Marten;
using Marten.Events.Projections;

namespace MyFreelanceGigs.Features.Gigs;

public static class GigsStartup
{
    public static void Register(this IServiceCollection serviceCollection)
    {

        serviceCollection.AddSingleton<IApiBuilder, GigsApiBuilder>();
        
        serviceCollection.ConfigureMarten(opts =>
        {
            opts.Projections.SelfAggregate<Gig>(ProjectionLifecycle.Async);
            //opts.Projections.Add<Lead>(ProjectionLifecycle.Inline);
        });
    }
}