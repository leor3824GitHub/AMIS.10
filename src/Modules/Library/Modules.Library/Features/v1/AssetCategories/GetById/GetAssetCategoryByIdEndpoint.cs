namespace FSH.Modules.Library.Features.v1.AssetCategories.GetById;

public static class GetAssetCategoryByIdEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/{id}", Handle)
            .WithName(nameof(GetAssetCategoryByIdQuery))
            .WithSummary("Get asset category by ID")
            .WithDescription("Retrieves a specific asset category by ID")
            .RequirePermission(LibraryPermissions.Categories.View)
            .Produces<AssetCategoryDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(new GetAssetCategoryByIdQuery(id), ct);
        return TypedResults.Ok(result);
    }
}
