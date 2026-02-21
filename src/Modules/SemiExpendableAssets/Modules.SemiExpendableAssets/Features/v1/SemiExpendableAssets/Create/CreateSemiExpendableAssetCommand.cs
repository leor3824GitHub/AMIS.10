using FSH.Framework.Core.Abstractions;
using FSH.Modules.SemiExpendableAssets.Contracts.DTOs;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Create;

/// <summary>Command to create a new semi-expendable asset.</summary>
public sealed record CreateSemiExpendableAssetCommand(
    string ICSNumber,
    string Description,
    string Category,
    DateTimeOffset AcquisitionDate,
    decimal AcquisitionCost) : ICommand<CreateSemiExpendableAssetResponse>;
