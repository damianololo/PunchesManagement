using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.ApplicationServices.API.Validators.Products;

public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
{
    private int[] allowedPageSizes = new[] { 5, 10, 15 };

    private string[] allowedSortByColumnNames = 
        { nameof(Product.Name), nameof(Product.Output), nameof(Product.ProductionTimeStart)};

    public GetProductsRequestValidator()
    {
        RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);

        RuleFor(r => r.PageSize).Custom((value, context) =>
        {
            if (!allowedPageSizes.Contains(value))
            {
                context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
            }
        });

        RuleFor(r => r.SortBy).Must(value => string.IsNullOrEmpty(value)  || allowedSortByColumnNames.Contains(value))
            .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
    }
}
