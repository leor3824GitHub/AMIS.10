using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Update;

/// <summary>Endpoint for updating a semi-expendable asset.</summary>
public static class UpdateSemiExpendableAssetEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPut("/{id}", Handle)
            .WithName(nameof(UpdateSemiExpendableAssetCommand))
            .WithSummary("Update a semi-expendable asset")
            .Produces<NoContent>(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .RequirePermission(SemiExpendableAssetsPermissionConstants.SemiExpendableAsset.Update);

    private static async Task<NoContent> Handle(
        Guid id,
        UpdateSemiExpendableAssetCommand baseCommand,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var command = baseCommand with { Id = id };
        await mediator.Send(command, cancellationToken);
        return TypedResults.NoContent();
    }
}
