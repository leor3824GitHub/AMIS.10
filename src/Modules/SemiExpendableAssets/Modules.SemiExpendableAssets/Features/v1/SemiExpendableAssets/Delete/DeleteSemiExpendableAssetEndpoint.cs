using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Delete;

/// <summary>Endpoint for deleting a semi-expendable asset.</summary>
public static class DeleteSemiExpendableAssetEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapDelete("/{id}", Handle)
            .WithName(nameof(DeleteSemiExpendableAssetCommand))
            .WithSummary("Delete a semi-expendable asset")
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .RequirePermission(SemiExpendableAssetsPermissionConstants.SemiExpendableAsset.Delete);

    private static async Task<NoContent> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new DeleteSemiExpendableAssetCommand(id);
        await mediator.Send(command, cancellationToken);
        return TypedResults.NoContent();
    }
}
