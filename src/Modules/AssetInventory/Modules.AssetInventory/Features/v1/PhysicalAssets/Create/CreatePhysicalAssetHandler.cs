using FSH.Modules.AssetInventory.Contracts.DTOs;
using FSH.Modules.AssetInventory.Domain;
using FSH.Framework.Core.Abstractions;
using FSH.Framework.Core.Context;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Create;

/// <summary>Handler for creating a new physical asset.</summary>
public sealed class CreatePhysicalAssetHandler(AssetInventoryDbContext dbContext, ICurrentUser currentUser)
    : ICommandHandler<CreatePhysicalAssetCommand, CreatePhysicalAssetResponse>
{
    public async ValueTask<CreatePhysicalAssetResponse> Handle(
        CreatePhysicalAssetCommand command,
        CancellationToken cancellationToken)
    {
        var asset = PhysicalAsset.Create(
            propertyNumber: command.PropertyNumber,
            description: command.Description,
            category: command.Category,
            acquisitionDate: command.AcquisitionDate,
            acquisitionCost: command.AcquisitionCost,
            usefulLifeDays: command.UsefulLifeDays,
            residualValue: command.ResidualValue,
            condition: Enum.Parse<AssetCondition>(command.Condition),
            status: Enum.Parse<AssetStatus>(command.Status),
            tenantId: currentUser.GetTenant()!,
            currentCustodianId: command.CurrentCustodianId,
            currentLocationId: command.CurrentLocationId,
            supplierId: command.SupplierId);

        dbContext.PhysicalAssets.Add(asset);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatePhysicalAssetResponse(asset.Id);
    }
}
