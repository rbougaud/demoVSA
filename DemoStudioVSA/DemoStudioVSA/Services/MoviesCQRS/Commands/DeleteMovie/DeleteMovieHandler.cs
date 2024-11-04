using MediatR;
using StudioVSA.Common.Helper;
using FluentValidation;
using StudioVSA.Domain.Abstractions;

namespace StudioVSA.Services.MoviesCQRS.Commands.DeleteMovie;

public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, Result<DeleteMovieResponse, ValidationException>>
{
    private readonly ILogger<DeleteMovieHandler> _logger;
    private readonly IMovieRepositoryWriter _movieRepository;

    public DeleteMovieHandler(ILogger<DeleteMovieHandler> logger, IMovieRepositoryWriter repositoryWriter)
    {
        _logger = logger;
        _movieRepository = repositoryWriter;
    }

    public async Task<Result<DeleteMovieResponse, ValidationException>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(DeleteMovieHandler));
        var result = await _movieRepository.RemoveAsync(request.Id);
        return new DeleteMovieResponse(result);
    }
}
