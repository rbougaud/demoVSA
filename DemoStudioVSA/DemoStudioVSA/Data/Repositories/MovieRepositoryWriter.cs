using StudioVSA.Common.Helper;
using StudioVSA.Data.Context;
using StudioVSA.Domain.Abstractions;
using StudioVSA.Domain.Entities;

namespace StudioVSA.Data.Repositories;

public class MovieRepositoryWriter(ILogger<MovieRepositoryWriter> logger, WriterContext context) : IMovieRepositoryWriter
{
    private readonly ILogger<MovieRepositoryWriter> _logger = logger;
    private readonly WriterContext _context = context;

    public async Task<Result<Guid, Exception>> AddAsync(Movie movie)
    {
        _logger.LogInformation(nameof(AddAsync));
        _context.Add(movie);
        var isSaved = await _context.SaveChangesAsync() > 0;
        return isSaved ? movie.Id : new Exception("Movie wasn't saved");
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        _logger.LogInformation(nameof(RemoveAsync));
        Movie? movie = await _context.Movies.FindAsync(id);
        if (movie is not null)
        {
            _context.Movies.Remove(movie);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<Result<bool, Exception>> UpdateAsync(IMovieDto movieDto)
    {
        _logger.LogInformation(nameof(UpdateAsync));
        Movie? movie = await _context.Movies.FindAsync(movieDto.Id);
        if(movie is not null)
        {
            _context.Movies.Update(movie);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }
}
