using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchesManagement.ApplicationServices.API.Handlers.UsersHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateUserHandler(
        IMapper mapper,
        IQueryExecutor queryExecutor,
        ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<DataAccess.Entities.User>(request);
            var command = new UpdateUserCommand()
            {
                Parameter = mappedUser,
            };
            var updatedUser = await _commandExecutor.Execute(command);
            var response = new UpdateUserResponse()
            {
                Data = _mapper.Map<Domain.Models.User>(updatedUser)
            };
            return response;
        }
    }
}
