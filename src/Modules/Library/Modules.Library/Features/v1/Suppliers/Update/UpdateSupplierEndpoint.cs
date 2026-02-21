namespace FSH.Modules.Library.Features.v1.Suppliers.Update;

public static class UpdateSupplierEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPut("/{id}", Handle)
            .WithName(nameof(UpdateSupplierCommand))
            .WithSummary("Update a supplier")
            .WithDescription("Updates an existing supplier")
            .RequirePermission(LibraryPermissions.Suppliers.Update)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<IResult> Handle(
        Guid id,
        UpdateSupplierRequest request,
        IMediator mediator,
        CancellationToken ct)
    {
        var cmd = new UpdateSupplierCommand(id, request.Name, request.Address, request.TIN, request.ContactPerson);
        await mediator.Send(cmd, ct);
        return TypedResults.NoContent();
    }
}
