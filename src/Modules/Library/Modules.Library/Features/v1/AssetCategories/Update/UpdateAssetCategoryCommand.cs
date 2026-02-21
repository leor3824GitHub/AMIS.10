namespace FSH.Modules.Library.Features.v1.AssetCategories.Update;

public sealed record UpdateAssetCategoryCommand(
    Guid Id,
    string Name,
    string Description,
    string Code) : ICommand;
