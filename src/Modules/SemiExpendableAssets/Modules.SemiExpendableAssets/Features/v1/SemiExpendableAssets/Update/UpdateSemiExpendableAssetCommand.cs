using FSH.Framework.Core.Abstractions;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Update;

/// <summary>Command to update a semi-expendable asset.</summary>
public sealed record UpdateSemiExpendableAssetCommand(
    Guid Id,
    string ICSNumber,
    string Description,
    string Category,
    DateTimeOffset AcquisitionDate,
    decimal AcquisitionCost) : ICommand<Unit>;
