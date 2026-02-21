namespace FSH.Modules.Library.Features.v1.Offices.Create;

public sealed class CreateOfficeHandler(
    LibraryDbContext dbContext,
    IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor) : ICommandHandler<CreateOfficeCommand, Guid>
{
    public async ValueTask<Guid> Handle(CreateOfficeCommand cmd, CancellationToken ct)
    {
        var tenantId = multiTenantContextAccessor.MultiTenantContext?.TenantInfo?.Id
            ?? throw new InvalidOperationException("No tenant context available");

        var office = Office.Create(cmd.Name, cmd.Location, cmd.Code, tenantId);
        dbContext.Offices.Add(office);
        await dbContext.SaveChangesAsync(ct);
        return office.Id;
    }
}
