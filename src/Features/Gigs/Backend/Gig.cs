using System.Collections.Immutable;
using System.Text.Json.Serialization;
using Marten;
using Marten.Events.Aggregation;
using MyFreelanceGigs.Features.Gigs;

namespace MyFreelanceGigs.Features.Gigs;

public class Gig
{

    public Gig()
    {
    }
    
    public void Apply(NewGigCreated gigCreated) =>
        (Id, Title) = (gigCreated.GigId, Validate(gigCreated.Title));
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? CompanyName { get; set; }
    public string? Broaker { get; set; }
    
    public DateTimeOffset StartTs { get; set; }
    
    public DateTimeOffset? EndTs { get; set; }

    internal bool ShouldDelete(GigDelete e) => true;

    private static string Validate(string name) =>
        string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException("Name must not be null or empty", nameof(name))
            : name;
    
}

