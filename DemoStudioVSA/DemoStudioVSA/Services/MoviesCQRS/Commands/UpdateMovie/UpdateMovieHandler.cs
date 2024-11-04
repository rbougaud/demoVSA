using FluentValidation;
using MediatR;
using StudioVSA.Common.Helper;
using StudioVSA.Domain.Abstractions;

namespace StudioVSA.Services.MoviesCQRS.Commands.UpdateMovie;

public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, Result<UpdateMovieResponse, ValidationException>>
{
    private readonly ILogger<UpdateMovieHandler> _logger;
    private readonly IMovieRepositoryWriter _movieRepositoryWriter;
    //private readonly IValidator<UpdateMovieCommand> _validator;
    public UpdateMovieHandler(ILogger<UpdateMovieHandler> logger, IMovieRepositoryWriter repositoryWriter) //, IValidator<UpdateMovieCommand> validator
    {
        _logger = logger;
        _movieRepositoryWriter = repositoryWriter;
        //_validator = validator;
    }

    public async Task<Result<UpdateMovieResponse, ValidationException>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(nameof(UpdateMovieHandler));
        //var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        //if (!validationResult.IsValid)
        //{
        //    return new ValidationException(validationResult.Errors);
        //}
        var result = await _movieRepositoryWriter.UpdateAsync(request.MovieDto);
        return new UpdateMovieResponse(result.Value);
    }
}
