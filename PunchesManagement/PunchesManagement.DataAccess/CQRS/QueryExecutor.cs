using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.DataAccess.CQRS;

public class QueryExecutor : IQueryExecutor
{
    private readonly PunchesManagementContext _context;

    public QueryExecutor(PunchesManagementContext context)
    {
        _context = context;
    }

    public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
    {
        return query.Execute(_context);
    }
}
