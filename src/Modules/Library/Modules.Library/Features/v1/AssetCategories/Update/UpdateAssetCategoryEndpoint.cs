namespace FSH.Modules.Library.Features.v1.AssetCategories.Update;

public static class UpdateAssetCategoryEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPut("/{id}", Handle)
            .WithName(nameof(UpdateAssetCategoryCommand))
            .WithSummary("Update an asset category")
            .WithDescription("Updates an existing asset category")
            .RequirePermission(LibraryPermissions.Categories.Update)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<IResult> Handle(
        Guid id,
        UpdateAssetCategoryRequest request,
        IMediator mediator,
        CancellationToken ct)
    {
        var cmd = new UpdateAssetCategoryCommand(id, request.Name, request.Description, request.Code);
        await mediator.Send(cmd, ct);
        return TypedResults.NoContent();
    }
}
