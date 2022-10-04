using PunchesManagement.DataAccess;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public abstract class CommandBase<TParameter, TResult>
{
    public abstract TParameter Parameter { get; set; }

    public abstract Task<TResult> Execute(PunchesManagementContext context);
}