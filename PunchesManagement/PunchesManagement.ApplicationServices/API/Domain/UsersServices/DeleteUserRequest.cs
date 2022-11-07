using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class DeleteUserRequest : RequestBase, IRequest<DeleteUserResponse>
{
    public int DeleteId { get; set; }
}
