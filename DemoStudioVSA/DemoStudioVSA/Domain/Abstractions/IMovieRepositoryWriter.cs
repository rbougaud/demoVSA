using StudioVSA.Common.Helper;
using StudioVSA.Domain.Entities;

namespace StudioVSA.Domain.Abstractions;

public interface IMovieRepositoryWriter
{
    Task<Result<Guid, Exception>> AddAsync(Movie movie);
    Task<Result<bool, Exception>> UpdateAsync(IMovieDto movieDto);
    Task<bool> RemoveAsync(Guid id);
}
