using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

namespace PunchesManagement.ApplicationServices.API.Validators.Products;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
	public UpdateProductRequestValidator()
	{
        RuleFor(x => x.Name).Length(1, 50);
        RuleFor(x => x.Series).Length(1, 20);
        RuleFor(x => x.Description).Length(0, 1500);
        RuleFor(x => x.BatchSize).ScalePrecision(6, 2);
        RuleFor(x => x.RealWorkingTime).ScalePrecision(6, 2);
    }
}
