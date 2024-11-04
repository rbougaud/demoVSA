namespace StudioVSA.Domain.Abstractions;

public interface IMovieDto
{
    Guid Id { get; init; }
    string Title { get; init; }
    string Author { get; init; }
    DateTime ReleaseDate { get; init; }
}
