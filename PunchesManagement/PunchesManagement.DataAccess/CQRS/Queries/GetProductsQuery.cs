using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetProductsQuery : QueryBase<List<Product>>
{
    public string SearchPhrase { get; set; }

    public override Task<List<Product>> Execute(PunchesManagementContext context)
    {
        return context.Products
            .Include(r => r.TabletPress)
            .Where(r => SearchPhrase == null
            || (r.Name.ToLower()
            .Contains(SearchPhrase.ToLower())))
            .ToListAsync();
    }
}
