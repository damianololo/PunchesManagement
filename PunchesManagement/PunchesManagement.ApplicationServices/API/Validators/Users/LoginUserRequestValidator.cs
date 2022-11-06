using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;

namespace PunchesManagement.ApplicationServices.API.Validators.Users
{
    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(x => x.UserName).Length(1, 50);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password)
                .WithMessage("Passwords cannot be different!");
        }
    }
}
