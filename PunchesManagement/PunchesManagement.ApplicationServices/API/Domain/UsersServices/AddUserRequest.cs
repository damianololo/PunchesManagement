using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class AddUserRequest : IRequest<AddUserResponse>
{
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public int UserRoleId { get; set; } = 1;
}
