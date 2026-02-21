namespace FSH.Modules.Library.Features.v1.Suppliers.GetById;

public static class GetSupplierByIdEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/{id}", Handle)
            .WithName(nameof(GetSupplierByIdQuery))
            .WithSummary("Get supplier by ID")
            .WithDescription("Retrieves a specific supplier by ID")
            .RequirePermission(LibraryPermissions.Suppliers.View)
            .Produces<SupplierDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(new GetSupplierByIdQuery(id), ct);
        return TypedResults.Ok(result);
    }
}
