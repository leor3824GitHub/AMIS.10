namespace FSH.Modules.Library.Features.v1.Suppliers.Delete;

public sealed class DeleteSupplierHandler(
    LibraryDbContext dbContext) : ICommandHandler<DeleteSupplierCommand>
{
    public async ValueTask<Unit> Handle(DeleteSupplierCommand cmd, CancellationToken ct)
    {
        var supplier = await dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == cmd.Id, ct)
            ?? throw new NotFoundException($"Supplier with id {cmd.Id} not found");

        dbContext.Suppliers.Remove(supplier);
        await dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}
