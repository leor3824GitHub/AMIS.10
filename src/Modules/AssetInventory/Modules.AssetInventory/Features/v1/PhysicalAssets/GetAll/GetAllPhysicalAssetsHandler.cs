using FSH.Modules.AssetInventory.Contracts.DTOs;
using FSH.Modules.AssetInventory.Domain;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.GetAll;

/// <summary>Handler for getting all physical assets with pagination.</summary>
public sealed class GetAllPhysicalAssetsHandler(AssetInventoryDbContext dbContext)
    : IQueryHandler<GetAllPhysicalAssetsQuery, PagedResponse<PhysicalAssetDto>>
{
    public async ValueTask<PagedResponse<PhysicalAssetDto>> Handle(
        GetAllPhysicalAssetsQuery query,
        CancellationToken cancellationToken)
    {
        // NOTE: Optimization pattern:
        // 1. AsNoTracking() for read-only queries (no change tracking overhead)
        // 2. Filter at DB level (Where)
        // 3. Order at DB level (OrderByDescending) - before Skip/Take
        // 4. Project to DTO before pagination (Select)
        // 5. Use ToPagedResponseAsync extension (handles Skip/Take at DB level)
        var dtos = dbContext.PhysicalAssets
            .AsNoTracking()
            .Where(x => string.IsNullOrEmpty(query.Search) ||
                 x.PropertyNumber.Contains(query.Search) ||
                 x.Description.Contains(query.Search) ||
                 x.Category.Contains(query.Search))
            .OrderByDescending(x => x.CreatedOnUtc)
            .Select(asset => new PhysicalAssetDto(
                asset.Id,
                asset.PropertyNumber,
                asset.Description,
                asset.Category,
                asset.AcquisitionDate,
                asset.AcquisitionCost,
                asset.UsefulLifeDays,
                asset.ResidualValue,
                asset.Condition.ToString(),
                asset.Status.ToString(),
                asset.CurrentCustodianId,
                asset.CurrentLocationId,
                asset.SupplierId));

        return await dtos.ToPagedResponseAsync(query, cancellationToken);
    }
}
