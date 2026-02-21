using FSH.Framework.Core.Abstractions;
using FSH.Framework.Core.Context;
using FSH.Framework.Core.Exceptions;
using FSH.Modules.AssetInventory.Domain;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Update;

/// <summary>Handler for updating a physical asset.</summary>
public sealed class UpdatePhysicalAssetHandler(AssetInventoryDbContext dbContext, ICurrentUser currentUser)
    : ICommandHandler<UpdatePhysicalAssetCommand, Unit>
{
    public async ValueTask<Unit> Handle(UpdatePhysicalAssetCommand command, CancellationToken cancellationToken)
    {
        var asset = await dbContext.PhysicalAssets.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException("Physical asset not found");

        // Use domain method to update
        asset.Update(
            propertyNumber: command.PropertyNumber,
            description: command.Description,
            category: command.Category,
            acquisitionDate: command.AcquisitionDate,
            acquisitionCost: command.AcquisitionCost,
            usefulLifeDays: command.UsefulLifeDays,
            residualValue: command.ResidualValue,
            condition: Enum.Parse<AssetCondition>(command.Condition),
            status: Enum.Parse<AssetStatus>(command.Status),
            currentCustodianId: command.CurrentCustodianId,
            currentLocationId: command.CurrentLocationId,
            supplierId: command.SupplierId,
            updatedBy: currentUser.GetUserId().ToString());

        dbContext.PhysicalAssets.Update(asset);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
