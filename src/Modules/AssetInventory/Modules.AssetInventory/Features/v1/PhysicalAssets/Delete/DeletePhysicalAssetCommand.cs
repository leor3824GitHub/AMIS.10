using FSH.Framework.Core.Abstractions;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Delete;

/// <summary>Command to delete a physical asset.</summary>
public sealed record DeletePhysicalAssetCommand(Guid Id) : ICommand<Unit>;
