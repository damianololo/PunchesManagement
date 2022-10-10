using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class TypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllTypesPunchesBySize([FromQuery] GetPunchesByTypesRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet]
    [Route("{typesId}")]
    public async Task<IActionResult> GetAllPunchesByTypesId([FromRoute]int typesId)
    {
        var request = new GetPunchesByTypesIdRequest()
        {
            TypesId = typesId
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
