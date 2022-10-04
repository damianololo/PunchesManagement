using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.DataAccess.CQRS;

public interface IQueryExecutor
{
    Task<TResult> Execute<TResult>(QueryBase<TResult> query);
}
