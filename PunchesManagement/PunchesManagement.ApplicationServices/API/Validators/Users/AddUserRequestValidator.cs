using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;

namespace PunchesManagement.ApplicationServices.API.Validators.Users;

public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
    {
        RuleFor(x => x.LastName).Length(1, 50);
        RuleFor(x => x.Username).Length(1, 50);
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.ConfirmPassword)
            .Equal(e => e.Password)
            .WithMessage("Passwords cannot be different!");
    }
}
