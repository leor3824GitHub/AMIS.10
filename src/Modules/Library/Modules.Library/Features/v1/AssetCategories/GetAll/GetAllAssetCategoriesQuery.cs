namespace FSH.Modules.Library.Features.v1.AssetCategories.GetAll;

public sealed record GetAllAssetCategoriesQuery : IPagedQuery, IQuery<PagedResponse<AssetCategoryDto>>
{
    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public string? Sort { get; set; }
}
