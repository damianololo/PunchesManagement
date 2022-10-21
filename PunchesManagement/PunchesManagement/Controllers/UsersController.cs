using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;

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

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute]int id)
    {
        var request = new GetUserByIdRequest()
        {
            SearchId = id
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var request = new DeleteUserRequest()
        {
            DeleteId = id
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateUserById([FromRoute] int id, [FromBody] UpdateUserRequest request)
    {
        request.UpdateId = id;
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
