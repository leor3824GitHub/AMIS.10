using FSH.Framework.Core.Abstractions;
using FSH.Framework.Core.Context;
using FSH.Modules.SemiExpendableAssets.Contracts.DTOs;
using FSH.Modules.SemiExpendableAssets.Domain;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Create;

/// <summary>Handler for creating a new semi-expendable asset.</summary>
public sealed class CreateSemiExpendableAssetHandler(
    SemiExpendableAssetsDbContext dbContext,
    ICurrentUser currentUser)
    : ICommandHandler<CreateSemiExpendableAssetCommand, CreateSemiExpendableAssetResponse>
{
    public async ValueTask<CreateSemiExpendableAssetResponse> Handle(
        CreateSemiExpendableAssetCommand command,
        CancellationToken cancellationToken)
    {
        var asset = SemiExpendableAsset.Create(
            icsNumber: command.ICSNumber,
            description: command.Description,
            category: command.Category,
            acquisitionDate: command.AcquisitionDate,
            acquisitionCost: command.AcquisitionCost,
            tenantId: currentUser.GetTenant()!);

        dbContext.SemiExpendableAssets.Add(asset);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateSemiExpendableAssetResponse(asset.Id);
    }
}
