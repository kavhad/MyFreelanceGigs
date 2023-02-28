using System.Text.Json.Serialization;

namespace MyFreelanceGigs.Features.Gigs;

public record GigDto
{
    public Guid Id { get; }
    public string Title { get; }

    [JsonConstructor]
    public GigDto(Guid id, string title) =>
        (Id, Title) = (id, title);
}