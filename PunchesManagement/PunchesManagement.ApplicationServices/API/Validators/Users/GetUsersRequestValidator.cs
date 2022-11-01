using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.ApplicationServices.API.Validators.Users;

public class GetUsersRequestValidator : AbstractValidator<GetUsersRequest>
{
    private int[] allowedPageSizes = new[] { 5, 10, 15 };

    private string[] allowedSortByColumnNames =
        { nameof(User.LastName), nameof(User.UserRole) };

    public GetUsersRequestValidator()
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
