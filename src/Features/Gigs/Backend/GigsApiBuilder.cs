namespace MyFreelanceGigs.Features.Gigs;

public class GigsApiBuilder : IApiBuilder
{
    public void BuildApi(WebApplication app)
    {
        string basePath = "api/v1";
        
        app.MapGet(basePath+"/gigs", GigsAppApi.GetAllLeads);
        
        //app.MapDelete(basePath+"/gigs", GigsAppApi.DeleteAll);
        
        app.MapGet(basePath+"/gig/{id}", GigsAppApi.GetLead);
        app.MapPost(basePath+"/gig", GigsAppApi.CreateLead);
        app.MapDelete(basePath+"/gig/{id}", GigsAppApi.Delete);
        
    }

}