using FSH.Framework.Core.Abstractions;
using FSH.Modules.SemiExpendableAssets.Contracts.DTOs;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.GetById;

/// <summary>Query to get a semi-expendable asset by ID.</summary>
public sealed record GetSemiExpendableAssetQuery(Guid Id) : IQuery<SemiExpendableAssetDto>;
