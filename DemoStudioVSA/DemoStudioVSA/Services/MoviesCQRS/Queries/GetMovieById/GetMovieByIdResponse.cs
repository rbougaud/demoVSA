using StudioVSA.Domain.Abstractions;

namespace StudioVSA.Services.MoviesCQRS.Queries.GetMovieById;

public record GetMovieByIdResponse(IMovieDto Movie);
