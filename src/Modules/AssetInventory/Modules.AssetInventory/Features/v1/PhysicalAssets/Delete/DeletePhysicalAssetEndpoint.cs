using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Delete;

/// <summary>Endpoint for deleting a physical asset.</summary>
public static class DeletePhysicalAssetEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapDelete("/{id}", Handle)
            .WithName(nameof(DeletePhysicalAssetCommand))
            .WithSummary("Delete a physical asset")
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .RequirePermission(AssetInventoryPermissionConstants.PhysicalAssets.Delete);

    private static async Task<NoContent> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = new DeletePhysicalAssetCommand(id);
        await mediator.Send(command, cancellationToken);
        return TypedResults.NoContent();
    }
}
