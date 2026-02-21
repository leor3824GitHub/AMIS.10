namespace FSH.Modules.Library.Features.v1.AssetCategories.Update;

public sealed class UpdateAssetCategoryHandler(
    LibraryDbContext dbContext) : ICommandHandler<UpdateAssetCategoryCommand>
{
    public async ValueTask<Unit> Handle(UpdateAssetCategoryCommand cmd, CancellationToken ct)
    {
        var assetCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == cmd.Id, ct)
            ?? throw new NotFoundException($"Asset Category with id {cmd.Id} not found");

        assetCategory.Update(cmd.Name, cmd.Description, cmd.Code);
        await dbContext.SaveChangesAsync(ct);
        return Unit.Value;
    }
}
