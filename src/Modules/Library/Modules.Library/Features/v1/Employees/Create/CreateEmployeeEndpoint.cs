namespace FSH.Modules.Library.Features.v1.Employees.Create;

public static class CreateEmployeeEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPost("/", Handle)
            .WithName(nameof(CreateEmployeeCommand))
            .WithSummary("Create a new employee")
            .WithDescription("Creates a new employee in the library")
            .RequirePermission(LibraryPermissions.Employees.Create)
            .Produces<Guid>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<IResult> Handle(
        CreateEmployeeRequest request,
        IMediator mediator,
        CancellationToken ct)
    {
        var cmd = new CreateEmployeeCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Position,
            request.OfficeId);

        var result = await mediator.Send(cmd, ct);
        return TypedResults.Created($"/api/v1/library/employees/{result}", result);
    }
}
