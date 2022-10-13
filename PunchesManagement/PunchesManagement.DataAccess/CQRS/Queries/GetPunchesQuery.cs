using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetPunchesQuery : QueryBase<List<Punches>>
{
    public string SearchSize { get; set; }
    public override Task<List<Punches>> Execute(PunchesManagementContext context)
    {
        return context.Punches.Include(x => x.Types).ToListAsync();

        //var punches = context.Punches.Include(r => r.Types);

        //var result = punches.Where(r => SearchSize == null
        //    || (r.Size.ToLower()
        //    .Contains(SearchSize.ToLower()))).ToListAsync();

        //return result;
    }
}
