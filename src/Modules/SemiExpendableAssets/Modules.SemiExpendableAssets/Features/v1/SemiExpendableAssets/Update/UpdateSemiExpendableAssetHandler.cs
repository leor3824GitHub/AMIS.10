using FSH.Framework.Core.Abstractions;
using FSH.Framework.Core.Context;
using FSH.Framework.Core.Exceptions;
using FSH.Modules.SemiExpendableAssets.Domain;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Update;

/// <summary>Handler for updating a semi-expendable asset.</summary>
public sealed class UpdateSemiExpendableAssetHandler(SemiExpendableAssetsDbContext dbContext, ICurrentUser currentUser)
    : ICommandHandler<UpdateSemiExpendableAssetCommand, Unit>
{
    public async ValueTask<Unit> Handle(
        UpdateSemiExpendableAssetCommand command,
        CancellationToken cancellationToken)
    {
        var asset = await dbContext.SemiExpendableAssets.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException("Semi-expendable asset not found");

        // Use domain method to update
        asset.Update(
            icsNumber: command.ICSNumber,
            description: command.Description,
            category: command.Category,
            acquisitionDate: command.AcquisitionDate,
            acquisitionCost: command.AcquisitionCost,
            updatedBy: currentUser.GetUserId().ToString());

        dbContext.SemiExpendableAssets.Update(asset);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
