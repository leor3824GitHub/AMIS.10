namespace FSH.Modules.Library.Features.v1.Suppliers.GetAll;

public static class GetAllSuppliersEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/", Handle)
            .WithName(nameof(GetAllSuppliersQuery))
            .WithSummary("Get all suppliers")
            .WithDescription("Retrieves a paginated list of all suppliers")
            .RequirePermission(LibraryPermissions.Suppliers.View)
            .Produces<PagedResponse<SupplierDto>>(StatusCodes.Status200OK);

    private static async Task<IResult> Handle(
        [AsParameters] GetAllSuppliersQuery query,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return TypedResults.Ok(result);
    }
}
