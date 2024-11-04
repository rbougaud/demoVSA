using MediatR;
using StudioVSA.Common.Helper;
using StudioVSA.Domain.Abstractions;
using StudioVSA.Mapping;

namespace StudioVSA.Services.MoviesCQRS.Commands.CreateMovie;

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, Result<AddMovieResponse, List<string>>>
{
    private readonly IMovieRepositoryWriter _repositoryMovie;
    private readonly ILogger<AddMovieCommandHandler> _logger;

    public AddMovieCommandHandler(ILogger<AddMovieCommandHandler> logger, IMovieRepositoryWriter repositoryMovie)
    {
        _logger = logger;
        _repositoryMovie = repositoryMovie;
    }

    public async Task<Result<AddMovieResponse, List<string>>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(AddMovieCommandHandler));
        var result = await _repositoryMovie.AddAsync(request.ToDao());

        return result.Match(
            success: id => Result<AddMovieResponse, List<string>>.Ok(new AddMovieResponse(result.Value)),
            failure: ex =>
            {
                _logger.LogError(ex, "Error adding movie");
                return Result<AddMovieResponse, List<string>>.Err(["Failed to add movie: " + ex.Message]);
            }
        );
    }
}
