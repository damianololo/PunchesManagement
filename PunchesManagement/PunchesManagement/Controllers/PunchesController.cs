using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class PunchesController : ControllerBase
{
	private readonly IMediator _mediator;

	public PunchesController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	[Route ("")]
	public async Task<IActionResult> GetAllPunches([FromQuery]GetPunchesRequest request)
	{
		var response = await _mediator.Send(request);

		return Ok(response);
	}

	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> GetPunchesById([FromRoute]int id)
	{
		var request = new GetPunchesByIdRequest()
		{
			SearchId = id
		};
		var response = await _mediator.Send(request);
		return Ok(response);
	}

	[HttpPost]
	[Route("")]
	public async Task<IActionResult> AddPunches([FromBody] AddPunchesRequest request)
	{
		var response = await _mediator.Send(request);

		return Ok(response);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> DeletePunches([FromRoute]int id)
	{
		var request = new DeletePunchesRequest()
		{
			DeleteId = id
		};
		var response = await _mediator.Send(request);
		return Ok(response);

    }
}
