using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

namespace PunchesManagement.ApplicationServices.API.Validators.Puncheses;

public class GetPunchesRequestValidator : AbstractValidator<GetPunchesRequest>
{
    private int[] allowedPageSizes = new[] { 5, 10, 15 };

    private string[] allowedSortByColumnNames =
        { nameof(DataAccess.Entities.Punches.Size), nameof(DataAccess.Entities.Punches.InInspection), nameof(DataAccess.Entities.Punches.Types)};

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

        RuleFor(r => r.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
            .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
    }
}
