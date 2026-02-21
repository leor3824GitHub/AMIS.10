using FSH.Framework.Core.Abstractions;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Delete;

/// <summary>Command to delete a semi-expendable asset.</summary>
public sealed record DeleteSemiExpendableAssetCommand(Guid Id) : ICommand<Unit>;
