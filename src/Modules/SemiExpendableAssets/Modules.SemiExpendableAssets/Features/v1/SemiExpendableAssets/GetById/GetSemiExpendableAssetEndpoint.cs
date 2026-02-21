using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using FSH.Modules.SemiExpendableAssets.Contracts.DTOs;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.GetById;

/// <summary>Endpoint for getting a semi-expendable asset by ID.</summary>
public static class GetSemiExpendableAssetEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/{id}", Handle)
            .WithName(nameof(GetSemiExpendableAssetQuery))
            .WithSummary("Get a semi-expendable asset by ID")
            .Produces<Ok<SemiExpendableAssetDto>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .RequirePermission(SemiExpendableAssetsPermissionConstants.SemiExpendableAsset.View);

    private static async Task<Ok<SemiExpendableAssetDto>> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var query = new GetSemiExpendableAssetQuery(id);
        var response = await mediator.Send(query, cancellationToken);
        return TypedResults.Ok(response);
    }
}
