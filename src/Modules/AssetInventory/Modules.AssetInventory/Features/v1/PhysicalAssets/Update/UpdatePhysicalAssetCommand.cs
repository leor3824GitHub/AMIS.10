using FSH.Framework.Core.Abstractions;
using FSH.Modules.AssetInventory.Contracts.DTOs;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Update;

/// <summary>Command to update a physical asset.</summary>
public sealed record UpdatePhysicalAssetCommand(
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
    Guid? CurrentCustodianId = null,
    Guid? CurrentLocationId = null,
    Guid? SupplierId = null) : ICommand<Unit>;
