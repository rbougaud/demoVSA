using MediatR;
using StudioVSA.Domain.Abstractions;
using StudioVSA.Mapping;

namespace StudioVSA.Services.MoviesCQRS.Queries.GetMovieById;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, GetMovieByIdResponse>
{
    private readonly ILogger<GetMovieByIdQueryHandler> _logger;
    private readonly IMovieRepositoryReader _repositoryMovieReader;

    public GetMovieByIdQueryHandler(ILogger<GetMovieByIdQueryHandler> logger, IMovieRepositoryReader repositoryMovieReader)
    {
        _logger = logger;
        _repositoryMovieReader = repositoryMovieReader;
    }

    public async Task<GetMovieByIdResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(GetMovieByIdQueryHandler));
        var movie = await _repositoryMovieReader.GetMovieByIdAsync(request.MovieId, cancellationToken);
        return new GetMovieByIdResponse(movie.ToDto());

    }
}
