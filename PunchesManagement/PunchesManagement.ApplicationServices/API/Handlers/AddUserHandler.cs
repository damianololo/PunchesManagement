using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<DataAccess.Entities.User>(request);
        var command = new AddUserCommand() { Parameter = user };
        var punchesFromDb = await _commandExecutor.Execute(command);
        return new AddUserResponse()
        {
            Data = _mapper.Map<Domain.Models.User>(punchesFromDb)
        };
    }
}
