using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

namespace PunchesManagement.ApplicationServices.API.Validators.Products;

public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
{
    private int[] allowedPageSizes = new[] { 5, 10, 15 }; 

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
    }
}
