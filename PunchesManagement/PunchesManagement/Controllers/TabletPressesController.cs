using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TabletPressesController : ApiControllerBase
{
	public TabletPressesController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet]
    [Route ("")]
    public Task<IActionResult> GetAllTabletPresses([FromQuery] GetTabletPressesRequest request)
    {
        return this.HandleRequest<GetTabletPressesRequest, GetTabletPressesResponse>(request);
    }

    [HttpGet]
    [Route("{id}")]
    public Task<IActionResult> GetTabletPressById([FromRoute]int id)
    {
        var request = new GetTabletPressByIdRequest()
        {
            SearchId = id
        };
        return this.HandleRequest<GetTabletPressByIdRequest, GetTabletPressResponse>(request);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddTabletPress([FromBody] AddTabletPressRequest request)
    {
        return this.HandleRequest<AddTabletPressRequest, AddTabletPressResponse>(request);
    }
    [HttpPut]
    [Route("{id}")]
    public Task<IActionResult> UpdateTabletPressById([FromRoute] int id, [FromBody] UpdateTabletPressRequest request)
    {
        request.UpdateId = id;
        return this.HandleRequest<UpdateTabletPressRequest, UpdateTabletPressResponse>(request);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteTabletPress([FromRoute] int id)
    {
        var request = new DeleteTabletPressRequest()
        {
            DeleteId = id
        };
        return this.HandleRequest<DeleteTabletPressRequest, DeleteTabletPressResponse>(request);
    }
}
