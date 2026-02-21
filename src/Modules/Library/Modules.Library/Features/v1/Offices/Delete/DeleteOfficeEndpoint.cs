namespace FSH.Modules.Library.Features.v1.Offices.Delete;

public static class DeleteOfficeEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapDelete("/{id}", Handle)
            .WithName(nameof(DeleteOfficeCommand))
            .WithSummary("Delete an office")
            .WithDescription("Deletes an existing office")
            .RequirePermission(LibraryPermissions.Offices.Delete)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        await mediator.Send(new DeleteOfficeCommand(id), ct);
        return TypedResults.NoContent();
    }
}
