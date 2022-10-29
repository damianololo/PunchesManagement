using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.Models;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
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
        var query = new GetUsersQuery()
        {
            SearchPhrase = request.SearchPhrase,
        };

        var users = await _queryExecutor.Execute(query);

        if (users is null)
        {
            return new GetUsersResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedUsers = _mapper.Map<List<Domain.Models.User>>(users);
        var totalItemsCount = query.TotalItemsCount;
        var result = new PagedResult<User>(mappedUsers, totalItemsCount, request.PageSize, request.PageNumber);

        var response = new GetUsersResponse()
        {
            Data = result
        };
        return response;
    }
}
