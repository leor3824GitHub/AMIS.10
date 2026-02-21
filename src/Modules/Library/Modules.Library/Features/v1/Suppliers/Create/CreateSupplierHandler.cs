namespace FSH.Modules.Library.Features.v1.Suppliers.Create;

public sealed class CreateSupplierHandler(
    LibraryDbContext dbContext,
    IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor) : ICommandHandler<CreateSupplierCommand, Guid>
{
    public async ValueTask<Guid> Handle(CreateSupplierCommand cmd, CancellationToken ct)
    {
        var tenantId = multiTenantContextAccessor.MultiTenantContext?.TenantInfo?.Id
            ?? throw new InvalidOperationException("No tenant context available");

        var supplier = Supplier.Create(cmd.Name, cmd.Address, cmd.TIN, cmd.ContactPerson, tenantId);
        dbContext.Suppliers.Add(supplier);
        await dbContext.SaveChangesAsync(ct);
        return supplier.Id;
    }
}
