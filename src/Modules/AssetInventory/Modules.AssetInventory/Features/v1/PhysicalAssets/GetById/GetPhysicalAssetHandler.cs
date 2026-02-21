using FSH.Framework.Core.Abstractions;
using FSH.Framework.Core.Exceptions;
using FSH.Modules.AssetInventory.Contracts.DTOs;
using FSH.Modules.AssetInventory.Domain;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.GetById;

/// <summary>Handler for getting a physical asset by ID.</summary>
public sealed class GetPhysicalAssetHandler(AssetInventoryDbContext dbContext)
    : IQueryHandler<GetPhysicalAssetQuery, PhysicalAssetDto>
{
    public async ValueTask<PhysicalAssetDto> Handle(GetPhysicalAssetQuery query, CancellationToken cancellationToken)
    {
        var asset = await dbContext.PhysicalAssets.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken)
            ?? throw new NotFoundException("Physical asset not found");

        return new PhysicalAssetDto(
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
            asset.SupplierId);
    }
}
