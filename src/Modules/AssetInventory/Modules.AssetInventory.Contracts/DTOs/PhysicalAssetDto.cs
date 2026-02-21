namespace FSH.Modules.AssetInventory.Contracts.DTOs;

/// <summary>DTO for PhysicalAsset entity.</summary>
public sealed record PhysicalAssetDto(
    Guid Id,
    string PropertyNumber,
    string Description,
    string Category,
    DateOnly AcquisitionDate,
    decimal AcquisitionCost,
    int UsefulLifeDays,
    decimal ResidualValue,
    string Condition,
    string Status,
    Guid? CurrentCustodianId,
    Guid? CurrentLocationId,
    Guid? SupplierId);

/// <summary>Response for CreatePhysicalAsset command.</summary>
public sealed record CreatePhysicalAssetResponse(Guid Id);

/// <summary>Request for updating a physical asset.</summary>
public sealed record UpdatePhysicalAssetRequest(
    string PropertyNumber,
    string Description,
    string Category,
    DateOnly AcquisitionDate,
    decimal AcquisitionCost,
    int UsefulLifeDays,
    decimal ResidualValue,
    string Condition,
    string Status,
    Guid? CurrentCustodianId,
    Guid? CurrentLocationId,
    Guid? SupplierId);
