using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;

namespace PunchesManagement.ApplicationServices.API.Validators.Users;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
	public UpdateUserRequestValidator()
	{
        RuleFor(x => x.FirstName).Length(0, 50);
        RuleFor(x => x.LastName).Length(1, 50);
        RuleFor(x => x.PasswordHash).Length(1, 50);
    }
}
