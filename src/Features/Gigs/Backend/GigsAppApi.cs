using System.Collections.Immutable;
using System.Linq.Expressions;
using Marten;
using Marten.AspNetCore;
using Marten.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MyFreelanceGigs.Features.Gigs;

public static class GigsAppApi
{ 
    
    [ProducesResponseType(type:typeof(Gig), statusCode:StatusCodes.Status200OK, contentType: "application/json")]

    public static async Task<Gig?> GetLead(Guid id, IDocumentStore documentStore, HttpContext context)
    {
        await using var session = documentStore.QuerySession();
        return session.Load<Gig>(id);
    }
    
    [ProducesResponseType(type:typeof(List<Gig>), statusCode:StatusCodes.Status200OK, contentType: "application/json")]
    internal static async Task GetAllLeads([FromServices] IDocumentStore documentStore, HttpContext context)
    {
        await using var session = documentStore.QuerySession();
        var ids =session.Events
            .QueryRawEventDataOnly<NewGigCreated>()
            .Select(x => x.GigId).ToImmutableList();
        await session.WriteArray(new GetAllGigs(), context);
    }

    public class GetAllGigs : ICompiledQuery<Gig, IEnumerable<Gig>>
    {
        public Expression<Func<IMartenQueryable<Gig>, IEnumerable<Gig>>> QueryIs()
            => q => q;
        
    }

    public static async Task CreateLead(HttpContext context, IDocumentStore documentStore, NewGigCreated newGigCreated)
    {
        await using var session = documentStore.LightweightSession();

        session.Events.StartStream<Gig>(newGigCreated.GigId, newGigCreated);
        await session.SaveChangesAsync();
    }
    
    /*
    public static async Task DeleteAll(IDocumentStore documentStore)
    {
        await documentStore.Advanced.ResetAllData();
        return;
    }*/
    
    
    public static async Task Delete(IDocumentStore documentStore, Guid id)
    {
        await using var session = documentStore.LightweightSession();
        session.Events.Append(id, new GigDelete());
        await session.SaveChangesAsync();
    }
    

}