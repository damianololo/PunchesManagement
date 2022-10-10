using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetPunchesByTypesQuery : QueryBase<List<Types>>
{
    public string SearchSize { get; set; }

    public override Task<List<Types>> Execute(PunchesManagementContext context)
    {
        //return context.Types.Include(r => r.Punches).ToListAsync();
        
        return context.Types
            .Include(r => r.Punches
            .Where(r => SearchSize == null 
            || (r.Size.ToLower()
            .Contains(SearchSize.ToLower()))))
            .ToListAsync();
    }
}
