using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudioVSA.Services.MoviesCQRS.Queries.GetMovieById;

namespace StudioVSA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesReaderController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("[action]")]
    public async Task<IActionResult> GetMovieById(GetMovieByIdRequest request)
    {
        var query = new GetMovieByIdQuery(request.Id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
