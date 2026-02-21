using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Create;

/// <summary>Endpoint for creating a new semi-expendable asset.</summary>
public static class CreateSemiExpendableAssetEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPost("/", Handle)
            .WithName(nameof(CreateSemiExpendableAssetCommand))
            .WithSummary("Create a new semi-expendable asset")
            .Produces<Created<CreateSemiExpendableAssetResponse>>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .RequirePermission(SemiExpendableAssetsPermissionConstants.SemiExpendableAsset.Create);

    private static async Task<Created<CreateSemiExpendableAssetResponse>> Handle(
        CreateSemiExpendableAssetCommand command,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(command, cancellationToken);
        return TypedResults.Created($"/api/v1/semi-expendable-assets/{response.Id}", response);
    }
}
