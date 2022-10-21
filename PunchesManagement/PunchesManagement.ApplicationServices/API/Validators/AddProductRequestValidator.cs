using FluentValidation;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

namespace PunchesManagement.ApplicationServices.API.Validators;

public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
{
	public AddProductRequestValidator()
	{
		RuleFor(x => x.Name).NotEmpty().Length(1,50);
        RuleFor(x => x.Series).NotEmpty().Length(1, 20);
        RuleFor(x => x.Description).Length(1, 1500);
        RuleFor(x => x.BatchSize).ScalePrecision(6, 2);
    }
}
