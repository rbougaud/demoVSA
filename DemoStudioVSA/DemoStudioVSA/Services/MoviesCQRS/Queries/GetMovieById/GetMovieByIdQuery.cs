using MediatR;

namespace StudioVSA.Services.MoviesCQRS.Queries.GetMovieById;

public record GetMovieByIdQuery(Guid MovieId) : IRequest<GetMovieByIdResponse>;
