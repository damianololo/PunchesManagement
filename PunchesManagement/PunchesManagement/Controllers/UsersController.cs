using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
	{
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }
}
