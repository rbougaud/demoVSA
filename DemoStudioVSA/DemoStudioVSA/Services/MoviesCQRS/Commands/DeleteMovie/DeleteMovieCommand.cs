using MediatR;
using StudioVSA.Common.Helper;
using FluentValidation;

namespace StudioVSA.Services.MoviesCQRS.Commands.DeleteMovie;

public record DeleteMovieCommand(Guid Id) : IRequest<Result<DeleteMovieResponse, ValidationException>>;
