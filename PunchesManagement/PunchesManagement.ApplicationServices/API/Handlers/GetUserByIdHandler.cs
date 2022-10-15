﻿using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUsersByIdQuery()
        {
            SearchId = request.SearchId
        };
        var user = await _queryExecutor.Execute(query);
        var mappedUser = _mapper.Map<Domain.Models.User>(user);
        var response = new GetUserByIdResponse()
        {
            Data = mappedUser 
        };
        return response;
    }
}