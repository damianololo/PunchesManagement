using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ApiControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IMediator mediator, ILogger<ProductsController> logger) 
        : base(mediator, logger)
	{
        _logger = logger;
    }

	[HttpGet]
    [Route("")]
	public Task<IActionResult> GetAllProducts([FromQuery]GetProductsRequest request)
	{
		return this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
	}

    [HttpGet]
    [Route("{id}")]
	public Task<IActionResult> GetProductById([FromRoute]int id)
	{
        var request = new GetProductByIdRequest()
        {
            SearchId = id
        };
        return this.HandleRequest<GetProductByIdRequest, GetProductByIdResponse>(request);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        return this.HandleRequest<AddProductRequest, AddProductResponse>(request);
    }
    [HttpPut]
    [Route("{id}")]
    public Task<IActionResult> UpdateProductById([FromRoute]int id, [FromBody] UpdateProductRequest request)
    {
        request.UpdateId = id;
        return this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteProduct([FromRoute]int id)
    {
        _logger.LogWarning($"Product with id: {id} DELETE action invoked.");
        var request = new DeleteProductRequest()
        {
            DeleteId = id
        };
        return this.HandleRequest<DeleteProductRequest, DeleteProductResponse>(request);
    }
}
