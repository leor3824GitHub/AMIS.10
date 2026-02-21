using FSH.Framework.Core.Abstractions;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.AssetInventory.Contracts.DTOs;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.GetAll;

/// <summary>Query to get all physical assets with pagination.</summary>
public sealed record GetAllPhysicalAssetsQuery(
    string? Search = null) : IPagedQuery, IQuery<PagedResponse<PhysicalAssetDto>>
{
    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public string? Sort { get; set; }
}
