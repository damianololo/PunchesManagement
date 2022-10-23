using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands.ProductsCommand;

public class AddProductCommand : CommandBase<Product, Product>
{
    public override async Task<Product> Execute(PunchesManagementContext context)
    {
        await context.Products.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
