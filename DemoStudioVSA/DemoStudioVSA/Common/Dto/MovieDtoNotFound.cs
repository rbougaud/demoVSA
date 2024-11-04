using StudioVSA.Domain.Abstractions;

namespace StudioVSA.Common.Dto;

public record MovieDtoNotFound : IMovieDto
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Title { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public DateTime ReleaseDate { get; init; }
}
