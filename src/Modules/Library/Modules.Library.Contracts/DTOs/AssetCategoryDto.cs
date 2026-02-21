namespace FSH.Modules.Library.Contracts.DTOs;

/// <summary>
/// Data Transfer Object for Asset Category.
/// </summary>
public record AssetCategoryDto(
    Guid Id,
    string Name,
    string Description,
    string Code,
    DateTimeOffset CreatedAtUtc);
