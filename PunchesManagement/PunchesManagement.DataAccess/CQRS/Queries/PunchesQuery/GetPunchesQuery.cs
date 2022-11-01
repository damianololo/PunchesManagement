using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;
using PunchesManagement.DataAccess.Enums;
using System.Linq.Expressions;

namespace PunchesManagement.DataAccess.CQRS.Queries.PunchesQuery;

public class GetPunchesQuery : QueryBase<List<Punches>>
{
    public string SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItemsCount { get; set; }

    public string SortBy { get; set; }
    public SortDirection SortDirection { get; set; }

    public override async Task<List<Punches>> Execute(PunchesManagementContext context)
    {
        var baseQuery = context.Punches
            .Include(r => r.Types)
            .Include(r => r.Manufacturer)
            .Where(r => SearchPhrase == null
            || (r.Size.ToLower()
            .Contains(SearchPhrase.ToLower())));

        TotalItemsCount = baseQuery.Count();

        if (!string.IsNullOrEmpty(SortBy))
        {
            var columnsSelectors = new Dictionary<string, Expression<Func<Punches, object>>>
            {
                {nameof(Punches.Size), r => r.Size },
                {nameof(Punches.InInspection), r => r.InInspection },
                {nameof(Punches.Types), r => r.Types }
            };

            var selectedColumn = columnsSelectors[SortBy];

            baseQuery = SortDirection == SortDirection.ASC
                ? baseQuery.OrderBy(selectedColumn)
                : baseQuery.OrderByDescending(selectedColumn);

        }

        var punches = await baseQuery
            .Skip(PageSize * (PageNumber - 1))
            .Take(PageSize)
            .ToListAsync();

        return punches;
    }
}
