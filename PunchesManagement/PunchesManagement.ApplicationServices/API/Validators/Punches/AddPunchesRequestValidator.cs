using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

namespace PunchesManagement.ApplicationServices.API.Validators.Punches;

public class AddPunchesRequestValidator : AbstractValidator<AddPunchesRequest>
{
	public AddPunchesRequestValidator()
	{
        RuleFor(x => x.Size).Length(1,10);
        RuleFor(x => x.Series).Length(1, 20);
    }
}
