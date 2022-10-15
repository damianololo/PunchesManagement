using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetPunchesQuery : QueryBase<List<Punches>>
{
    public string SearchPhrase { get; set; }
    public override Task<List<Punches>> Execute(PunchesManagementContext context)
    {
        return context.Punches
            .Include(r => r.Types)
            .Where(r => SearchPhrase == null
            || (r.Size.ToLower()
            .Contains(SearchPhrase.ToLower())))
            .ToListAsync();
    }
}
