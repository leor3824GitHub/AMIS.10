using FSH.Framework.Core.Abstractions;
using FSH.Framework.Core.Exceptions;
using FSH.Modules.SemiExpendableAssets.Domain;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Delete;

/// <summary>Handler for deleting a semi-expendable asset.</summary>
public sealed class DeleteSemiExpendableAssetHandler(SemiExpendableAssetsDbContext dbContext)
    : ICommandHandler<DeleteSemiExpendableAssetCommand, Unit>
{
    public async ValueTask<Unit> Handle(
        DeleteSemiExpendableAssetCommand command,
        CancellationToken cancellationToken)
    {
        var asset = await dbContext.SemiExpendableAssets.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken)
            ?? throw new NotFoundException("Semi-expendable asset not found");

        dbContext.SemiExpendableAssets.Remove(asset);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
