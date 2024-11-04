using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudioVSA.Services.MoviesCQRS.Commands.CreateMovie;
using StudioVSA.Services.MoviesCQRS.Commands.DeleteMovie;
using StudioVSA.Services.MoviesCQRS.Commands.UpdateMovie;

namespace StudioVSA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesWriterController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("[action]")]
    public async Task<IActionResult> AddMovie([FromBody] AddMovieCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsFailure ? BadRequest(result.Error) : Ok(result.Value);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand request)
    {
        var result = await _mediator.Send(request);
        return result.IsFailure ? BadRequest(result.Error) : Ok(result.Value);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteMovie([FromBody] DeleteMovieCommand request)
    {
        var result = await _mediator.Send(request);
        return result.IsFailure ? BadRequest(result.Error) : Ok(result.Value);
    }
}
