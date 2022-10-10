using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
	private readonly IMediator _mediator;

	public ProductsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
    [Route("")]
	public async Task<IActionResult> GetAllProducts([FromQuery]GetProductsRequest request)
	{
		var response = await _mediator.Send(request);

		return Ok(response);
	}

    [HttpGet]
    [Route("{id}")]
	public async Task<IActionResult> GetProduct([FromQuery]GetProductRequest request, [FromRoute]int id)
	{
		var response = await _mediator.Send(request);

		return Ok(response);
	}
}
