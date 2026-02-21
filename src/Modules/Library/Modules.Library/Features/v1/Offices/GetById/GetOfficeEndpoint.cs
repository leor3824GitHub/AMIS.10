namespace FSH.Modules.Library.Features.v1.Offices.GetById;

public static class GetOfficeEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/{id}", Handle)
            .WithName(nameof(GetOfficeQuery))
            .WithSummary("Get an office by ID")
            .WithOpenApi()
            .RequirePermission(LibraryPermissions.Offices.View);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(new GetOfficeQuery(id), ct);
        return TypedResults.Ok(result);
    }
}
