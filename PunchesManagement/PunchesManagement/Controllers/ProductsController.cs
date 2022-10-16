using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

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
	public async Task<IActionResult> GetProductById([FromRoute]int id)
	{
        var request = new GetProductByIdRequest()
        {
            SearchId = id
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute]int id)
    {
        var request = new DeleteProductRequest()
        {
            DeleteId = id
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
