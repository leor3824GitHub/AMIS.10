namespace FSH.Modules.Library.Features.v1.Employees.Update;

public sealed class UpdateEmployeeHandler(
    LibraryDbContext dbContext) : ICommandHandler<UpdateEmployeeCommand>
{
    public async ValueTask<Unit> Handle(UpdateEmployeeCommand cmd, CancellationToken ct)
    {
        var employee = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == cmd.Id, ct)
            ?? throw new NotFoundException($"Employee with id {cmd.Id} not found");

        employee.Update(cmd.FirstName, cmd.LastName, cmd.Position, cmd.OfficeId);
        dbContext.Employees.Update(employee);
        await dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}
