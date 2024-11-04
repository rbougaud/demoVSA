using StudioVSA.Data.Context;
using StudioVSA.Domain.Abstractions;
using StudioVSA.Domain.Entities;

namespace StudioVSA.Data.Repositories;

public class MovieRepositoryReader(ILogger<MovieRepositoryReader> logger, ReaderContext context) : IMovieRepositoryReader
{
    private readonly ILogger<MovieRepositoryReader> _logger = logger;
    private readonly ReaderContext _context = context;

    public async Task<Movie?> GetMovieByIdAsync(Guid movieId, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(GetMovieByIdAsync));
        return await _context.Movies.FindAsync(movieId);
    }
}
