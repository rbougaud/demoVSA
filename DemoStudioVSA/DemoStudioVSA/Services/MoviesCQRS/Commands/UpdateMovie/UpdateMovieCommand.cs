using FluentValidation;
using MediatR;
using StudioVSA.Common.Dto;
using StudioVSA.Common.Helper;

namespace StudioVSA.Services.MoviesCQRS.Commands.UpdateMovie;

public record UpdateMovieCommand(MovieDto MovieDto) : IRequest<Result<UpdateMovieResponse, ValidationException>>;
