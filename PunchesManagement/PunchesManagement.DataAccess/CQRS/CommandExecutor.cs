using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.CQRS.Commands;

namespace PunchesManagement.DataAccess.CQRS;

public class CommandExecutor : ICommandExecutor
{
    private readonly PunchesManagementContext _context;

    public CommandExecutor(PunchesManagementContext context)
    {
        _context = context;
    }

    public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
    {
        return command.Execute(_context);
    }
}
