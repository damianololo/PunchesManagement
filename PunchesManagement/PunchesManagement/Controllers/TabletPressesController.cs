using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

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

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetTabletPressById([FromRoute]int id)
    {
        var request = new GetTabletPressByIdRequest()
        {
            SearchId = id
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddTabletPress([FromBody] AddTabletPressRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTabletPress([FromRoute] int id)
    {
        var request = new DeleteTabletPressRequest()
        {
            DeleteId = id
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
