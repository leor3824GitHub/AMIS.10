namespace FSH.Modules.Library.Features.v1.Employees.GetAll;

public static class GetAllEmployeesEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/", Handle)
            .WithName(nameof(GetAllEmployeesQuery))
            .WithSummary("Get all employees")
            .WithDescription("Retrieves a paginated list of all employees")
            .RequirePermission(LibraryPermissions.Employees.View)
            .Produces<PagedResponse<EmployeeDto>>(StatusCodes.Status200OK);

    private static async Task<IResult> Handle(
        [AsParameters] GetAllEmployeesQuery query,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return TypedResults.Ok(result);
    }
}
