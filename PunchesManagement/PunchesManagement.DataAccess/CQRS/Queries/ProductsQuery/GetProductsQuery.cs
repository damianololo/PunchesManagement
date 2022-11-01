using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;
using PunchesManagement.DataAccess.Enums;
using System.Linq.Expressions;

namespace PunchesManagement.DataAccess.CQRS.Queries.ProductsQuery;

public class GetProductsQuery : QueryBase<List<Product>>
{
    public string SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItemsCount { get; set; }

    public string SortBy { get; set; }
    public SortDirection SortDirection { get; set; }

    public override async Task<List<Product>> Execute(PunchesManagementContext context)
    {
        var baseQuery = context.Products
            .Include(r => r.TabletPress)
            .Where(r => SearchPhrase == null
            || (r.Name.ToLower()
            .Contains(SearchPhrase.ToLower())));
            
        TotalItemsCount = baseQuery.Count();

        if (!string.IsNullOrEmpty(SortBy))
        {
            var columnsSelectors = new Dictionary<string, Expression<Func<Product, object>>>
            {
                {nameof(Product.Name), r => r.Name },
                {nameof(Product.Output), r => r.Output },
                {nameof(Product.ProductionTimeStart), r => r.ProductionTimeStart }
            };

            var selectedColumn = columnsSelectors[SortBy];

            baseQuery = SortDirection == SortDirection.ASC
                ? baseQuery.OrderBy(selectedColumn)
                : baseQuery.OrderByDescending(selectedColumn);

        }

        var products = await baseQuery
            .Skip(PageSize * (PageNumber - 1))
            .Take(PageSize)
            .ToListAsync();

        return products;
    }
}
