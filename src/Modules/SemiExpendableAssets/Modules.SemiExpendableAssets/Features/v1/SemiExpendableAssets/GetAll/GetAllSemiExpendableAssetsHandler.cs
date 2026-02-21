using FSH.Modules.SemiExpendableAssets.Contracts.DTOs;
using FSH.Modules.SemiExpendableAssets.Domain;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.GetAll;

/// <summary>Handler for getting all semi-expendable assets with pagination.</summary>
public sealed class GetAllSemiExpendableAssetsHandler(SemiExpendableAssetsDbContext dbContext)
    : IQueryHandler<GetAllSemiExpendableAssetsQuery, PagedResponse<SemiExpendableAssetDto>>
{
    public async ValueTask<PagedResponse<SemiExpendableAssetDto>> Handle(
        GetAllSemiExpendableAssetsQuery query,
        CancellationToken cancellationToken)
    {
        // NOTE: Optimization pattern:
        // 1. AsNoTracking() for read-only queries (no change tracking overhead)
        // 2. Filter at DB level (Where)
        // 3. Order at DB level (OrderByDescending) - before Skip/Take
        // 4. Project to DTO before pagination (Select)
        // 5. Use ToPagedResponseAsync extension (handles Skip/Take at DB level)
        var dtos = dbContext.SemiExpendableAssets
            .AsNoTracking()
            .Where(x => string.IsNullOrEmpty(query.Search) ||
                 x.ICSNumber.Contains(query.Search) ||
                 x.Description.Contains(query.Search) ||
                 x.Category.Contains(query.Search))
            .OrderByDescending(x => x.CreatedOnUtc)
            .Select(asset => new SemiExpendableAssetDto(
                asset.Id,
                asset.ICSNumber,
                asset.Description,
                asset.Category,
                asset.AcquisitionDate,
                asset.AcquisitionCost,
                asset.Condition.ToString(),
                asset.Status.ToString(),
                asset.CurrentCustodianId,
                asset.CurrentLocationId,
                asset.ReceiptReferenceId));

        return await dtos.ToPagedResponseAsync(query, cancellationToken);
    }
}
