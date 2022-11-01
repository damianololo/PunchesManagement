using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries.TabletPressQuery;

public class GetTabletPressesQuery : QueryBase<List<TabletPress>>
{
    public string SearchPhrase { get; set; }

    public override Task<List<TabletPress>> Execute(PunchesManagementContext context)
    {
        return context.TabletPresses
            .Include(x => x.Types)
            .Where(x => SearchPhrase == null
            || (x.Name.ToLower()
            .Contains(SearchPhrase.ToLower())))
            .ToListAsync();
    }
}
