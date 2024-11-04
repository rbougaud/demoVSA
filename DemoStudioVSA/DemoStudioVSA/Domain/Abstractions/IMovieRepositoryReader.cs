using StudioVSA.Domain.Entities;

namespace StudioVSA.Domain.Abstractions;

public interface IMovieRepositoryReader
{
    Task<Movie?> GetMovieByIdAsync(Guid movieId, CancellationToken cancellationToken);
}
