using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUsersQuery();
        var users = await _queryExecutor.Execute(query);
        var mappedUsers = _mapper.Map<List<Domain.Models.User>>(users);
        var response = new GetUsersResponse()
        {
            Data = mappedUsers
        };
        return response;
    }
}
