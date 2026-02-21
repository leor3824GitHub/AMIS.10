namespace FSH.Modules.Library.Features.v1.AssetCategories.GetAll;

public sealed class GetAllAssetCategoriesHandler(
    LibraryDbContext dbContext) : IQueryHandler<GetAllAssetCategoriesQuery, PagedResponse<AssetCategoryDto>>
{
    public async ValueTask<PagedResponse<AssetCategoryDto>> Handle(GetAllAssetCategoriesQuery query, CancellationToken ct)
    {
        var assetCategories = dbContext.Categories.AsNoTracking()
            .OrderBy(c => c.Name);

        var dtos = assetCategories.Select(c => new AssetCategoryDto(
            c.Id, c.Name, c.Description, c.Code, c.CreatedOnUtc));

        return await dtos.ToPagedResponseAsync(query, ct);
    }
}
