namespace FSH.Modules.Library.Features.v1.AssetCategories.Create;

public sealed record CreateAssetCategoryCommand(
    string Name,
    string Description,
    string Code) : ICommand<Guid>;
