using FSH.Framework.Core.Abstractions;
using FSH.Framework.Core.Exceptions;
using FSH.Modules.AssetInventory.Domain;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Delete;

/// <summary>Handler for deleting a physical asset.</summary>
public sealed class DeletePhysicalAssetHandler(AssetInventoryDbContext dbContext)
    : ICommandHandler<DeletePhysicalAssetCommand, Unit>
{
    public async ValueTask<Unit> Handle(DeletePhysicalAssetCommand command, CancellationToken cancellationToken)
    {
        var asset = await dbContext.PhysicalAssets.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException("Physical asset not found");

        dbContext.PhysicalAssets.Remove(asset);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
