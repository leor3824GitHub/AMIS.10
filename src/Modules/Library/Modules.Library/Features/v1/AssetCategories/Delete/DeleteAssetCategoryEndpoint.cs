namespace FSH.Modules.Library.Features.v1.AssetCategories.Delete;

public static class DeleteAssetCategoryEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapDelete("/{id}", Handle)
            .WithName(nameof(DeleteAssetCategoryCommand))
            .WithSummary("Delete an asset category")
            .WithDescription("Deletes an existing asset category")
            .RequirePermission(LibraryPermissions.Categories.Delete)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        await mediator.Send(new DeleteAssetCategoryCommand(id), ct);
        return TypedResults.NoContent();
    }
}
