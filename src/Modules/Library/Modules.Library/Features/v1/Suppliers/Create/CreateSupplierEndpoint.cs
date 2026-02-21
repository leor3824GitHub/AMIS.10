namespace FSH.Modules.Library.Features.v1.Suppliers.Create;

public static class CreateSupplierEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPost("/", Handle)
            .WithName(nameof(CreateSupplierCommand))
            .WithSummary("Create a new supplier")
            .WithDescription("Creates a new supplier")
            .RequirePermission(LibraryPermissions.Suppliers.Create)
            .Produces<Guid>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<IResult> Handle(
        CreateSupplierRequest request,
        IMediator mediator,
        CancellationToken ct)
    {
        var cmd = new CreateSupplierCommand(request.Name, request.Address, request.TIN, request.ContactPerson);
        var result = await mediator.Send(cmd, ct);
        return TypedResults.Created($"/api/v1/library/suppliers/{result}", result);
    }
}
