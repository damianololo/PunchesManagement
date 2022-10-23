using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

namespace PunchesManagement.ApplicationServices.API.Validators.TabletPresses;

public class UpdateTabletPressRequestValidator : AbstractValidator<UpdateTabletPressRequest>
{
	public UpdateTabletPressRequestValidator()
	{
        RuleFor(x => x.Name).Length(1, 20);
        RuleFor(x => x.Producer).Length(0, 20);
    }
}
