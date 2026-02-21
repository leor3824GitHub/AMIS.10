namespace FSH.Modules.Library.Features.v1.Employees.Delete;

public static class DeleteEmployeeEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapDelete("/{id}", Handle)
            .WithName(nameof(DeleteEmployeeCommand))
            .WithSummary("Delete an employee")
            .WithDescription("Deletes an existing employee")
            .RequirePermission(LibraryPermissions.Employees.Delete)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        await mediator.Send(new DeleteEmployeeCommand(id), ct);
        return TypedResults.NoContent();
    }
}
