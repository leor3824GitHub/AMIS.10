namespace FSH.Modules.Library.Features.v1.Employees.GetById;

public static class GetEmployeeByIdEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/{id}", Handle)
            .WithName(nameof(GetEmployeeByIdQuery))
            .WithSummary("Get employee by ID")
            .WithDescription("Retrieves a specific employee by their ID")
            .RequirePermission(LibraryPermissions.Employees.View)
            .Produces<EmployeeDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(new GetEmployeeByIdQuery(id), ct);
        return TypedResults.Ok(result);
    }
}
