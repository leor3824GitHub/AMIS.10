namespace FSH.Modules.Library.Features.v1.AssetCategories.Create;

public sealed class CreateAssetCategoryHandler(
    LibraryDbContext dbContext,
    IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor) : ICommandHandler<CreateAssetCategoryCommand, Guid>
{
    public async ValueTask<Guid> Handle(CreateAssetCategoryCommand cmd, CancellationToken ct)
    {
        var tenantId = multiTenantContextAccessor.MultiTenantContext?.TenantInfo?.Id
            ?? throw new InvalidOperationException("No tenant context available");

        var category = AssetCategory.Create(cmd.Name, cmd.Description, cmd.Code, tenantId);
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync(ct);
        return category.Id;
    }
}
