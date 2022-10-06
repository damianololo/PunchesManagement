using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TabletPressesController : ControllerBase
{
	private readonly IMediator _mediator;

	public TabletPressesController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
    [Route ("")]
    public async Task<IActionResult> GetAllTabletPresses([FromQuery] GetTabletPressesRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }
}
