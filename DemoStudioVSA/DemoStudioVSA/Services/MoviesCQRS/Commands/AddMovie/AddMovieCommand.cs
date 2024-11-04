using MediatR;
using StudioVSA.Common.Helper;

namespace StudioVSA.Services.MoviesCQRS.Commands.CreateMovie;

public record AddMovieCommand(string Title, string Author, DateTime ReleaseDate) : IRequest<Result<AddMovieResponse, List<string>>>;
