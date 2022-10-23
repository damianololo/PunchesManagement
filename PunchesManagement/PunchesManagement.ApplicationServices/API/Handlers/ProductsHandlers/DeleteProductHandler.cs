using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands.ProductsCommand;

namespace PunchesManagement.ApplicationServices.API.Handlers.ProductsHandlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public DeleteProductHandler(IMapper mapper, 
        ICommandExecutor commandExecutor, 
        IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        //var query = new GetProductByIdQuery()
        //{ 
        //    SearchId = request.DeleteId 
        //};
        //var getProduct = await _queryExecutor.Execute(query);
        //if (getProduct == null)
        //{
        //    return new DeleteProductResponse()
        //    {
        //        Error = new ErrorModel(ErrorType.NotFound)
        //    };
        //}
        var mappedProduct = _mapper.Map<DataAccess.Entities.Product>(request);
        var command = new DeleteProductCommand()
        { 
            Parameter = mappedProduct 
        };
        var deleteProduct = await _commandExecutor.Execute(command);
        var response = new DeleteProductResponse()
        {
            Data = _mapper.Map<Domain.Models.Product>(deleteProduct)
        };
        return response;
    }
}
