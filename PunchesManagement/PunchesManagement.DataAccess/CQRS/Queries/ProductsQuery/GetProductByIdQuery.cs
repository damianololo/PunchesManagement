using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries.ProductsQuery;

public class GetProductByIdQuery : QueryBase<Product>
{
    public int SearchId { get; set; }
    public override async Task<Product> Execute(PunchesManagementContext context)
    {
        var product = await context.Products.Include(r => r.TabletPress).FirstOrDefaultAsync(x => x.Id == SearchId);
        return product;
    }
}
