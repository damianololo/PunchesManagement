using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries
{
    public class GetTabletPressByIdQuery : QueryBase<TabletPress>
    {
        public int SearchId { get; set; }

        public override async Task<TabletPress> Execute(PunchesManagementContext context)
        {
            var tabletPress = await context.TabletPresses.Include(x => x.Types).FirstOrDefaultAsync(x => x.Id == SearchId);
            return tabletPress;
        }
    }
}
