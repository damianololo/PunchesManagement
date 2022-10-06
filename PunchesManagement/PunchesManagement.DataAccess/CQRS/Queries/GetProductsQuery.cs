using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetProductsQuery : QueryBase<List<Product>>
{
    public override Task<List<Product>> Execute(PunchesManagementContext context)
    {
        return context.Products.ToListAsync();
    }
}
