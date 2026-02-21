namespace FSH.Modules.Library.Features.v1.AssetCategories.GetById;

public sealed record GetAssetCategoryByIdQuery(Guid Id) : IQuery<AssetCategoryDto>;
