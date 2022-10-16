using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class DeletePunchesCommand : CommandBase<Punches, Punches>
{
    public override async Task<Punches> Execute(PunchesManagementContext context)
    {
        context.ChangeTracker.Clear();
        context.Punches.RemoveRange(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
