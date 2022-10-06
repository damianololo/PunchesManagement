using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetProductQuery : QueryBase<Product>
{
    public int Id { get; set; }
    public override async Task<Product> Execute(PunchesManagementContext context)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == Id);
        return product;
    }
}
