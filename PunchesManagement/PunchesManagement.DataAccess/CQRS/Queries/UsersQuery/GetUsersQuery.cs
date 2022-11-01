using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;
using PunchesManagement.DataAccess.Enums;
using System.Linq.Expressions;

namespace PunchesManagement.DataAccess.CQRS.Queries.UsersQuery;

public class GetUsersQuery : QueryBase<List<User>>
{
    public string SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItemsCount { get; set; }

    public string SortBy { get; set; }
    public SortDirection SortDirection { get; set; }

    public override async Task<List<User>> Execute(PunchesManagementContext context)
    {
        var baseQuery = context.Users
            .Include(x => x.UserRole)
            .Where(r => SearchPhrase == null
            || (r.LastName.ToLower()
            .Contains(SearchPhrase.ToLower())));

        TotalItemsCount = baseQuery.Count();

        if (!string.IsNullOrEmpty(SortBy))
        {
            var columnsSelectors = new Dictionary<string, Expression<Func<User, object>>>
            {
                {nameof(User.LastName), r => r.LastName },
                {nameof(User.UserRole), r => r.UserRole }
            };

            var selectedColumn = columnsSelectors[SortBy];

            baseQuery = SortDirection == SortDirection.ASC
                ? baseQuery.OrderBy(selectedColumn)
                : baseQuery.OrderByDescending(selectedColumn);

        }

        var users = await baseQuery
            .Skip(PageSize * (PageNumber - 1))
            .Take(PageSize)
            .ToListAsync();

        return users;
    }
}
