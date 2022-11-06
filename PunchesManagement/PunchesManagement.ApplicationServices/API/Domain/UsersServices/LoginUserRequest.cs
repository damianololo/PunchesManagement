using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class LoginUserRequest : IRequest<LoginUserResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
