using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class DeleteProductCommand : CommandBase<Product, Product>
{
    public override async Task<Product> Execute(PunchesManagementContext context)
    {
        context.ChangeTracker.Clear();
        context.Products.RemoveRange(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
