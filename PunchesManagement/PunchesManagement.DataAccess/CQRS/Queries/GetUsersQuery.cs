using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetUsersQuery : QueryBase<List<User>>
{
    public override Task<List<User>> Execute(PunchesManagementContext context)
    {
        return context.Users.Include(x => x.UserRole).ToListAsync();
    }
}
