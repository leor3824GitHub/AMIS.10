using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using FSH.Modules.AssetInventory.Contracts.DTOs;

namespace FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.GetAll;

/// <summary>Endpoint for getting all physical assets with pagination.</summary>
public static class GetAllPhysicalAssetsEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/", Handle)
            .WithName(nameof(GetAllPhysicalAssetsQuery))
            .WithSummary("Get all physical assets")
            .Produces<Ok<PagedResponse<PhysicalAssetDto>>>(StatusCodes.Status200OK)
            .RequirePermission(AssetInventoryPermissionConstants.PhysicalAssets.View);

    private static async Task<Ok<PagedResponse<PhysicalAssetDto>>> Handle(
        string? search,
        int pageNumber = 1,
        int pageSize = 10,
        IMediator? mediator = null,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAllPhysicalAssetsQuery(search)
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var response = await mediator!.Send(query, cancellationToken);
        return TypedResults.Ok(response);
    }
}
