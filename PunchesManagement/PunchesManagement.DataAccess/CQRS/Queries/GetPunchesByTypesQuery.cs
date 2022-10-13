using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetPunchesByTypesQuery : QueryBase<List<Types>>
{
    public override Task<List<Types>> Execute(PunchesManagementContext context)
    {
        var punchesbyTypes =  context.Types.Include(r => r.Punches).ToListAsync();
        
        return punchesbyTypes;
    }
}
