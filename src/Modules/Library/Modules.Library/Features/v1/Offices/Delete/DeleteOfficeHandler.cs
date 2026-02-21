namespace FSH.Modules.Library.Features.v1.Offices.Delete;

public sealed class DeleteOfficeHandler(
    LibraryDbContext dbContext) : ICommandHandler<DeleteOfficeCommand>
{
    public async ValueTask<Unit> Handle(DeleteOfficeCommand cmd, CancellationToken ct)
    {
        var office = await dbContext.Offices.FirstOrDefaultAsync(x => x.Id == cmd.Id, ct)
            ?? throw new NotFoundException($"Office with id {cmd.Id} not found");

        dbContext.Offices.Remove(office);
        await dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}
