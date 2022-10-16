using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class DeleteUserRequest : IRequest<DeleteUserResponse>
{
    public int DeleteId { get; set; }
}
