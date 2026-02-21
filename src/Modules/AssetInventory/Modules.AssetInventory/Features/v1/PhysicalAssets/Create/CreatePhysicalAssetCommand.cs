using FSH.Framework.Core.Abstractions;
using FSH.Modules.AssetInventory.Contracts.DTOs;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Create;

/// <summary>Command to create a new physical asset.</summary>
public sealed record CreatePhysicalAssetCommand(
    string PropertyNumber,
    string Description,
    string Category,
    DateOnly AcquisitionDate,
    decimal AcquisitionCost,
    int UsefulLifeDays,
    decimal ResidualValue,
    string Condition,
    string Status,
    Guid? CurrentCustodianId = null,
    Guid? CurrentLocationId = null,
    Guid? SupplierId = null) : ICommand<CreatePhysicalAssetResponse>;
