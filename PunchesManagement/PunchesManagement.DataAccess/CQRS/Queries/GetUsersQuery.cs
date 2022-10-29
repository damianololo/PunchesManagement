using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetUsersQuery : QueryBase<List<User>>
{
    public string SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItemsCount { get; set; }

    public override Task<List<User>> Execute(PunchesManagementContext context)
    {
        var baseQuery = context.Users
            .Include(x => x.UserRole)
            .Where(r => SearchPhrase == null
            || (r.LastName.ToLower()
            .Contains(SearchPhrase.ToLower())));

        TotalItemsCount = baseQuery.Count();

        var users = baseQuery
            .Skip(PageSize * (PageNumber - 1))
            .Take(PageSize)
            .ToListAsync();

        return users;
    }
}
