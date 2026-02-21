namespace FSH.Modules.Library.Features.v1.Employees.Update;

public static class UpdateEmployeeEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPut("/{id}", Handle)
            .WithName(nameof(UpdateEmployeeCommand))
            .WithSummary("Update an employee")
            .WithDescription("Updates an existing employee")
            .RequirePermission(LibraryPermissions.Employees.Update)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<IResult> Handle(
        Guid id,
        UpdateEmployeeRequest request,
        IMediator mediator,
        CancellationToken ct)
    {
        var cmd = new UpdateEmployeeCommand(
            id,
            request.FirstName,
            request.LastName,
            request.Position,
            request.OfficeId);

        await mediator.Send(cmd, ct);
        return TypedResults.NoContent();
    }
}
