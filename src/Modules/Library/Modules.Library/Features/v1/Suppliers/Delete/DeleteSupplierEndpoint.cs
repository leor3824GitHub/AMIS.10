namespace FSH.Modules.Library.Features.v1.Suppliers.Delete;

public static class DeleteSupplierEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapDelete("/{id}", Handle)
            .WithName(nameof(DeleteSupplierCommand))
            .WithSummary("Delete a supplier")
            .WithDescription("Deletes an existing supplier")
            .RequirePermission(LibraryPermissions.Suppliers.Delete)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        await mediator.Send(new DeleteSupplierCommand(id), ct);
        return TypedResults.NoContent();
    }
}
