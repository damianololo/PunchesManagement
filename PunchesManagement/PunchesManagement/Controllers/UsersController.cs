using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ApiControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(IMediator mediator, ILogger<UsersController> logger) 
        : base(mediator, logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
    {
        return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
    }

    [HttpGet]
    [Route("{id}")]
    public Task<IActionResult> GetUserById([FromRoute]int id)
    {
        var request = new GetUserByIdRequest()
        {
            SearchId = id
        };
        return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
    }

    [HttpPost]
    [Route("")]
    public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
    {
        return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
    }
    [HttpPut]
    [Route("{id}")]
    public Task<IActionResult> UpdateUserById([FromRoute] int id, [FromBody] UpdateUserRequest request)
    {
        request.UpdateId = id;
        return this.HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        _logger.LogWarning($"User with id: {id} DELETE action invoked.");
        var request = new DeleteUserRequest()
        {
            DeleteId = id
        };
        return this.HandleRequest<DeleteUserRequest, DeleteUserResponse>(request);
    }
}
