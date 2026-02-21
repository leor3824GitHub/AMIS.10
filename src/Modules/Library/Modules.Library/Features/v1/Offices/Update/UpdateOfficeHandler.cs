namespace FSH.Modules.Library.Features.v1.Offices.Update;

public sealed class UpdateOfficeHandler(
    LibraryDbContext dbContext) : ICommandHandler<UpdateOfficeCommand>
{
    public async ValueTask<Unit> Handle(UpdateOfficeCommand cmd, CancellationToken ct)
    {
        var office = await dbContext.Offices.FirstOrDefaultAsync(x => x.Id == cmd.Id, ct)
            ?? throw new NotFoundException($"Office with id {cmd.Id} not found");

        office.Update(cmd.Name, cmd.Location, cmd.Code);
        await dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}
