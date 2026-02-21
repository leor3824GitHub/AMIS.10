using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using FSH.Modules.SemiExpendableAssets.Contracts.DTOs;

namespace FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.GetAll;

/// <summary>Endpoint for getting all semi-expendable assets with pagination.</summary>
public static class GetAllSemiExpendableAssetsEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/", Handle)
            .WithName(nameof(GetAllSemiExpendableAssetsQuery))
            .WithSummary("Get all semi-expendable assets")
            .Produces<Ok<PagedResponse<SemiExpendableAssetDto>>>(StatusCodes.Status200OK)
            .RequirePermission(SemiExpendableAssetsPermissionConstants.SemiExpendableAsset.View);

    private static async Task<Ok<PagedResponse<SemiExpendableAssetDto>>> Handle(
        string? search,
        int pageNumber = 1,
        int pageSize = 10,
        IMediator? mediator = null,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAllSemiExpendableAssetsQuery(search)
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var response = await mediator!.Send(query, cancellationToken);
        return TypedResults.Ok(response);
    }
}
