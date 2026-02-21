namespace FSH.Modules.Library.Contracts.DTOs;

/// <summary>
/// Data Transfer Object for Supplier.
/// </summary>
public record SupplierDto(
    Guid Id,
    string Name,
    string Address,
    string TIN,
    string ContactPerson,
    DateTimeOffset CreatedAtUtc);
