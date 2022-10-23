using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands.ProductsCommand;

namespace PunchesManagement.ApplicationServices.API.Handlers.ProductsHandlers;

public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddProductHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<DataAccess.Entities.Product>(request);
        var command = new AddProductCommand() { Parameter = product };
        var punchesFromDb = await _commandExecutor.Execute(command);
        return new AddProductResponse()
        {
            Data = _mapper.Map<Domain.Models.Product>(punchesFromDb)
        };
    }
}
