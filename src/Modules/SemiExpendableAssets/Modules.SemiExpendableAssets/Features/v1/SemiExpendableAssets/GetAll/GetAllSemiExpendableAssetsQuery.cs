using FSH.Framework.Core.Abstractions;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.SemiExpendableAssets.Contracts.DTOs;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.GetAll;

/// <summary>Query to get all semi-expendable assets with pagination.</summary>
public sealed record GetAllSemiExpendableAssetsQuery(
    string? Search = null) : IPagedQuery, IQuery<PagedResponse<SemiExpendableAssetDto>>
{
    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public string? Sort { get; set; }
}
