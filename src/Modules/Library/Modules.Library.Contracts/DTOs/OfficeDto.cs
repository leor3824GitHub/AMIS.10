namespace FSH.Modules.Library.Contracts.DTOs;

/// <summary>
/// Data Transfer Object for Office.
/// </summary>
public record OfficeDto(
    Guid Id,
    string Name,
    string Location,
    string Code,
    DateTimeOffset CreatedAtUtc);
