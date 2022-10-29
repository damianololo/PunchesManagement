using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetPunchesQuery : QueryBase<List<Punches>>
{
    public string SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItemsCount { get; set; }

    public override Task<List<Punches>> Execute(PunchesManagementContext context)
    {
        var baseQuery = context.Punches
            .Include(r => r.Types)
            .Include(r => r.Manufacturer)
            .Where(r => SearchPhrase == null
            || (r.Size.ToLower()
            .Contains(SearchPhrase.ToLower())));

        TotalItemsCount = baseQuery.Count();

        var punches = baseQuery
            .Skip(PageSize * (PageNumber - 1))
            .Take(PageSize)
            .ToListAsync();

        return punches;
    }
}
