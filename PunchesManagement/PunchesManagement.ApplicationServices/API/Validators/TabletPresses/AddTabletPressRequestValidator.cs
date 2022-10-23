using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

namespace PunchesManagement.ApplicationServices.API.Validators.TabletPresses;

public class AddTabletPressRequestValidator : AbstractValidator<AddTabletPressRequest>
{
	public AddTabletPressRequestValidator()
	{
        RuleFor(x => x.Name).Length(1, 20);
        RuleFor(x => x.Producer).Length(0, 20);
    }
}
