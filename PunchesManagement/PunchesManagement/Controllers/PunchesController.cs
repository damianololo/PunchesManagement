using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class PunchesController : ApiControllerBase
{
	public PunchesController(IMediator mediator) :base(mediator)
	{
	}

	[HttpGet]
	[Route ("")]
	public Task<IActionResult> GetAllPunches([FromQuery]GetPunchesRequest request)
	{
        return this.HandleRequest<GetPunchesRequest, GetPunchesResponse>(request);
    }

	[HttpGet]
	[Route("{id}")]
	public Task<IActionResult> GetPunchesById([FromRoute]int id)
	{
		var request = new GetPunchesByIdRequest()
		{
			SearchId = id
		};
        return this.HandleRequest<GetPunchesByIdRequest, GetPunchesByIdResponse>(request);
    }

	[HttpPost]
	[Route("")]
	public Task<IActionResult> AddPunches([FromBody] AddPunchesRequest request)
	{
        return this.HandleRequest<AddPunchesRequest, AddPunchesResponse>(request);
    }
    [HttpPut]
    [Route("{id}")]
    public Task<IActionResult> UpdatePunchesById([FromRoute] int id, [FromBody] UpdatePunchesRequest request)
    {
        request.UpdateId = id;
        return this.HandleRequest<UpdatePunchesRequest, UpdatePunchesResponse>(request);
	}

	[HttpDelete]
	[Route("{id}")]
	public Task<IActionResult> DeletePunches([FromRoute]int id)
	{
		var request = new DeletePunchesRequest()
		{
			DeleteId = id
		};
        return this.HandleRequest<DeletePunchesRequest, DeletePunchesResponse>(request);
    }
}
