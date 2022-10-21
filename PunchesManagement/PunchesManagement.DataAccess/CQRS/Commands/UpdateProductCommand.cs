using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class UpdateProductCommand : CommandBase<Product, Product>
{
    public override async Task<Product> Execute(PunchesManagementContext context)
    {
        context.ChangeTracker.Clear();
        context.Products.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
