namespace FSH.Modules.SemiExpendableAssets.Contracts.DTOs;

/// <summary>DTO for SemiExpendableAsset entity.</summary>
public sealed record SemiExpendableAssetDto(
    Guid Id,
    string ICSNumber,
    string Description,
    string Category,
    DateTimeOffset AcquisitionDate,
    decimal AcquisitionCost,
    string Condition,
    string Status,
    Guid? CurrentCustodianId,
    Guid? CurrentLocationId,
    Guid? ReceiptReferenceId);

/// <summary>Response for creating a semi-expendable asset.</summary>
public sealed record CreateSemiExpendableAssetResponse(Guid Id);
