using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands.PunchesCommand;

public class AddPunchesCommand : CommandBase<Punches, Punches>
{
    public override async Task<Punches> Execute(PunchesManagementContext context)
    {
        await context.Punches.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
