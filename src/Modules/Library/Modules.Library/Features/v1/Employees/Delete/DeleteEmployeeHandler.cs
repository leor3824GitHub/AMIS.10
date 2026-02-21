namespace FSH.Modules.Library.Features.v1.Employees.Delete;

public sealed class DeleteEmployeeHandler(
    LibraryDbContext dbContext) : ICommandHandler<DeleteEmployeeCommand>
{
    public async ValueTask<Unit> Handle(DeleteEmployeeCommand cmd, CancellationToken ct)
    {
        var employee = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == cmd.Id, ct)
            ?? throw new NotFoundException($"Employee with id {cmd.Id} not found");

        dbContext.Employees.Remove(employee);
        await dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}
