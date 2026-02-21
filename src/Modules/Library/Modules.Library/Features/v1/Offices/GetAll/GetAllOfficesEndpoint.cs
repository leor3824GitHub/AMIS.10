namespace FSH.Modules.Library.Features.v1.Offices.GetAll;

public static class GetAllOfficesEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/", Handle)
            .WithName(nameof(GetAllOfficesQuery))
            .WithSummary("Get all offices")
            .WithDescription("Retrieves a paginated list of all offices")
            .RequirePermission(LibraryPermissions.Offices.View)
            .Produces<PagedResponse<OfficeDto>>(StatusCodes.Status200OK);

    private static async Task<IResult> Handle(
        [AsParameters] GetAllOfficesQuery query,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(query, ct);
        return TypedResults.Ok(result);
    }
}
