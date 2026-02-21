using FSH.Framework.Core.Abstractions;
using FSH.Modules.AssetInventory.Contracts.DTOs;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.GetById;

/// <summary>Query to get a physical asset by ID.</summary>
public sealed record GetPhysicalAssetQuery(Guid Id) : IQuery<PhysicalAssetDto>;
