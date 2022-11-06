using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands.ProductsCommand;
using PunchesManagement.DataAccess.CQRS.Queries.ProductsQuery;

namespace PunchesManagement.ApplicationServices.API.Handlers.ProductsHandlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
{
	private readonly IMapper _mapper;
	private readonly IQueryExecutor _queryExecutor;
	private readonly ICommandExecutor _commandExecutor;

	public UpdateProductHandler(
		IMapper mapper, 
		IQueryExecutor queryExecutor, 
		ICommandExecutor commandExecutor)
	{
		_mapper = mapper;
		_queryExecutor = queryExecutor;
		_commandExecutor = commandExecutor;
	}

	public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
	{
		var query = new GetProductByIdQuery()
		{
			SearchId = request.UpdateId
		};
		var product = await _queryExecutor.Execute(query);

		if (product is null)
		{
			return new UpdateProductResponse()
			{
				Error = new ErrorModel(ErrorType.NotFound)
			};
		}

		var mappedProduct = _mapper.Map<DataAccess.Entities.Product>(request);

		var command = new UpdateProductCommand()
		{
			Parameter = mappedProduct,
		};

		var updatedProduct = await _commandExecutor.Execute(command);

		var response = new UpdateProductResponse()
		{
			Data = _mapper.Map<Domain.Models.Product>(updatedProduct)
		};

		return response;
    }
}