using FSH.Framework.Core.Exceptions;
using FSH.Modules.SemiExpendableAssets.Contracts.DTOs;
using FSH.Modules.SemiExpendableAssets.Domain;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.GetById;

/// <summary>Handler for getting a semi-expendable asset by ID.</summary>
public sealed class GetSemiExpendableAssetHandler(SemiExpendableAssetsDbContext dbContext)
    : IQueryHandler<GetSemiExpendableAssetQuery, SemiExpendableAssetDto>
{
    public async ValueTask<SemiExpendableAssetDto> Handle(
        GetSemiExpendableAssetQuery query,
        CancellationToken cancellationToken)
    {
        var asset = await dbContext.SemiExpendableAssets.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken)
            ?? throw new NotFoundException("Semi-expendable asset not found");

        return new SemiExpendableAssetDto(
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
            asset.ReceiptReferenceId);
    }
}
