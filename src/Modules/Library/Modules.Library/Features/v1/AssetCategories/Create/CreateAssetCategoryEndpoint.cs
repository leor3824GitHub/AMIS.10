namespace FSH.Modules.Library.Features.v1.AssetCategories.Create;

public static class CreateAssetCategoryEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPost("/", Handle)
            .WithName(nameof(CreateAssetCategoryCommand))
            .WithSummary("Create a new asset category")
            .WithDescription("Creates a new asset category for classification")
            .RequirePermission(LibraryPermissions.Categories.Create)
            .Produces<Guid>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<IResult> Handle(
        CreateAssetCategoryRequest request,
        IMediator mediator,
        CancellationToken ct)
    {
        var cmd = new CreateAssetCategoryCommand(request.Name, request.Description, request.Code);
        var result = await mediator.Send(cmd, ct);
        return TypedResults.Created($"/api/v1/library/asset-categories/{result}", result);
    }
}
