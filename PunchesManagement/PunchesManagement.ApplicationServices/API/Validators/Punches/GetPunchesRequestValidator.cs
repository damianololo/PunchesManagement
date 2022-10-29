using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

namespace PunchesManagement.ApplicationServices.API.Validators.Punches;

public class GetPunchesRequestValidator : AbstractValidator<GetPunchesRequest>
{
    private int[] allowedPageSizes = new[] { 5, 10, 15 };

    public GetPunchesRequestValidator()
	{
        RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(r => r.PageSize).Custom((value, context) =>
        {
            if (!allowedPageSizes.Contains(value))
            {
                context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
            }
        });
    }
}
