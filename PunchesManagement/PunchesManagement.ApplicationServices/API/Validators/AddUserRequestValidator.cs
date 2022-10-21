using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;

namespace PunchesManagement.ApplicationServices.API.Validators;

public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
	public AddUserRequestValidator()
	{
        RuleFor(x => x.FirstName).Length(1, 50);
        RuleFor(x => x.LastName).Length(1, 50).NotEmpty();
        RuleFor(x => x.PasswordHash).Length(1, 50).NotEmpty();
    }
}
