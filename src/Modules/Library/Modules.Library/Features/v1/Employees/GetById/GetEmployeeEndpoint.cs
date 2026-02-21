namespace FSH.Modules.Library.Features.v1.Employees.GetById;

public static class GetEmployeeEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/{id}", Handle)
            .WithName(nameof(GetEmployeeQuery))
            .WithSummary("Get an employee by ID")
            .WithOpenApi()
            .RequirePermission(LibraryPermissions.Employees.View);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(new GetEmployeeQuery(id), ct);
        return TypedResults.Ok(result);
    }
}
