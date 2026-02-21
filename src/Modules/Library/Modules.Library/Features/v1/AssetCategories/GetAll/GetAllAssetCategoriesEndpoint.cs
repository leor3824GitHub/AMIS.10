namespace FSH.Modules.Library.Features.v1.AssetCategories.GetAll;

public static class GetAllAssetCategoriesEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/", Handle)
            .WithName(nameof(GetAllAssetCategoriesQuery))
            .WithSummary("Get all asset categories")
            .WithDescription("Retrieves a paginated list of all asset categories")
            .RequirePermission(LibraryPermissions.Categories.View)
            .Produces<PagedResponse<AssetCategoryDto>>(StatusCodes.Status200OK);

    private static async Task<IResult> Handle(
        [AsParameters] GetAllAssetCategoriesQuery query,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return TypedResults.Ok(result);
    }
}
