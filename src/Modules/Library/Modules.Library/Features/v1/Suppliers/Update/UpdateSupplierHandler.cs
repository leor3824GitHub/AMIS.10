namespace FSH.Modules.Library.Features.v1.Suppliers.Update;

public sealed class UpdateSupplierHandler(
    LibraryDbContext dbContext) : ICommandHandler<UpdateSupplierCommand>
{
    public async ValueTask<Unit> Handle(UpdateSupplierCommand cmd, CancellationToken ct)
    {
        var supplier = await dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == cmd.Id, ct)
            ?? throw new NotFoundException($"Supplier with id {cmd.Id} not found");

        supplier.Update(cmd.Name, cmd.Address, cmd.TIN, cmd.ContactPerson);
        await dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}
