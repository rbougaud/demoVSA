using StudioVSA.Domain.Abstractions;

namespace StudioVSA.Common.Dto;

public record MovieDto : IMovieDto
{
    public Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Author { get; init; }
    public DateTime ReleaseDate { get; init; }
}
