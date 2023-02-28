using System.Text.Json.Serialization;

namespace MyFreelanceGigs.Features.Gigs;



public record NewGigCreated(Guid GigId, string Title);