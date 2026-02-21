using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using FSH.Modules.AssetInventory.Contracts.DTOs;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.GetById;

/// <summary>Endpoint for getting a physical asset by ID.</summary>
public static class GetPhysicalAssetEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/{id}", Handle)
            .WithName(nameof(GetPhysicalAssetQuery))
            .WithSummary("Get a physical asset by ID")
            .Produces<Ok<PhysicalAssetDto>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .RequirePermission(AssetInventoryPermissionConstants.PhysicalAssets.View);

    private static async Task<Ok<PhysicalAssetDto>> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var query = new GetPhysicalAssetQuery(id);
        var response = await mediator.Send(query, cancellationToken);
        return TypedResults.Ok(response);
    }
}
