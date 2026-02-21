using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Create;

/// <summary>Endpoint for creating a new physical asset.</summary>
public static class CreatePhysicalAssetEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPost("/", Handle)
            .WithName(nameof(CreatePhysicalAssetCommand))
            .WithSummary("Create a new physical asset")
            .Produces<Created<CreatePhysicalAssetResponse>>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .RequirePermission(AssetInventoryPermissionConstants.PhysicalAssets.Create);

    private static async Task<Created<CreatePhysicalAssetResponse>> Handle(
        CreatePhysicalAssetCommand command,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(command, cancellationToken);
        return TypedResults.Created($"/api/v1/physical-assets/{response.Id}", response);
    }
}
