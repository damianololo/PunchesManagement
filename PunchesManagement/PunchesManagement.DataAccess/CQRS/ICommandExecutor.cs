using PunchesManagement.DataAccess.CQRS.Commands;

namespace PunchesManagement.DataAccess.CQRS;

public interface ICommandExecutor
{
    Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
}
