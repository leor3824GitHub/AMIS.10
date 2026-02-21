namespace FSH.Modules.Library.Contracts.DTOs;

public sealed record CreateAssetCategoryRequest(
    string Name,
    string Description,
    string Code);

public sealed record UpdateAssetCategoryRequest(
    string Name,
    string Description,
    string Code);

public sealed record CreateAssetCategoryResponse(Guid Id);
