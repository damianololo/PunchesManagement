using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetProductsQuery : QueryBase<List<Product>>
{
    public string SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItemsCount { get; set; }

    public override Task<List<Product>> Execute(PunchesManagementContext context)
    {
        var baseQuery = context.Products
            .Include(r => r.TabletPress)
            .Where(r => SearchPhrase == null
            || (r.Name.ToLower()
            .Contains(SearchPhrase.ToLower())));
            
        TotalItemsCount = baseQuery.Count();

        var products = baseQuery
            .Skip(PageSize * (PageNumber - 1))
            .Take(PageSize)
            .ToListAsync();

        return products;
    }
}
