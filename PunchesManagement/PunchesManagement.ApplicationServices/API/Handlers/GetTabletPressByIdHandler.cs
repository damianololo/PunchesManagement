using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetTabletPressByIdHandler : IRequestHandler<GetTabletPressByIdRequest, GetTabletPressByIdResponse>
{
	private readonly IMapper _mapper;
	private readonly IQueryExecutor _queryExecutor;

	public GetTabletPressByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
	{
		_mapper = mapper;
		_queryExecutor = queryExecutor;
	}

	public async Task<GetTabletPressByIdResponse> Handle(GetTabletPressByIdRequest request, CancellationToken cancellationToken)
	{
		var query = new GetTabletPressByIdQuery()
		{
			SearchId = request.SearchId,
		};
		var tabletPress = await _queryExecutor.Execute(query);
		var mappedTabletPress = _mapper.Map<Domain.Models.TabletPress>(tabletPress);
		var response = new GetTabletPressByIdResponse()
		{ 
			Data = mappedTabletPress 
		};
		return response;
    }
}
