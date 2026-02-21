namespace FSH.Modules.Library.Features.v1.AssetCategories.Delete;

public sealed class DeleteAssetCategoryHandler(
    LibraryDbContext dbContext) : ICommandHandler<DeleteAssetCategoryCommand>
{
    public async ValueTask<Unit> Handle(DeleteAssetCategoryCommand cmd, CancellationToken ct)
    {
        var assetCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == cmd.Id, ct)
            ?? throw new NotFoundException($"Asset Category with id {cmd.Id} not found");

        dbContext.Categories.Remove(assetCategory);
        await dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}
