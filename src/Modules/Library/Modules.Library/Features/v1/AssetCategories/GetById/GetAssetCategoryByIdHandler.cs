namespace FSH.Modules.Library.Features.v1.AssetCategories.GetById;

public sealed class GetAssetCategoryByIdHandler(
    LibraryDbContext dbContext) : IQueryHandler<GetAssetCategoryByIdQuery, AssetCategoryDto>
{
    public async ValueTask<AssetCategoryDto> Handle(GetAssetCategoryByIdQuery query, CancellationToken ct)
    {
        var assetCategory = await dbContext.Categories.AsNoTracking()
            .Where(x => x.Id == query.Id)
            .Select(x => new AssetCategoryDto(x.Id, x.Name, x.Description, x.Code, x.CreatedOnUtc))
            .FirstOrDefaultAsync(ct) ?? throw new NotFoundException($"Asset Category with id {query.Id} not found");

        return assetCategory;
    }
}
