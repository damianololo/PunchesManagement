using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

namespace PunchesManagement.ApplicationServices.API.Validators.Punches;

public class UpdatePunchesRequestValidator : AbstractValidator<UpdatePunchesRequest>
{
	public UpdatePunchesRequestValidator()
	{
        RuleFor(x => x.Size).Length(1, 10);
        RuleFor(x => x.Series).Length(1, 20);
        RuleFor(x => x.MachineHour).ScalePrecision(6, 2);
    }
}
