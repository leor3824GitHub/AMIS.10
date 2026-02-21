using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Update;

/// <summary>Endpoint for updating a physical asset.</summary>
public static class UpdatePhysicalAssetEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPut("/{id}", Handle)
            .WithName(nameof(UpdatePhysicalAssetCommand))
            .WithSummary("Update a physical asset")
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .RequirePermission(AssetInventoryPermissionConstants.PhysicalAssets.Update);

    private static async Task<NoContent> Handle(
        Guid id,
        UpdatePhysicalAssetCommand baseCommand,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = baseCommand with { Id = id };
        await mediator.Send(command, cancellationToken);
        return TypedResults.NoContent();
    }
}
