namespace FSH.Modules.Library.Features.v1.Offices.GetById;

public static class GetOfficeByIdEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapGet("/{id}", Handle)
            .WithName(nameof(GetOfficeByIdQuery))
            .WithSummary("Get office by ID")
            .WithDescription("Retrieves a specific office by ID")
            .RequirePermission(LibraryPermissions.Offices.View)
            .Produces<OfficeDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

    private static async Task<IResult> Handle(
        Guid id,
        IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(new GetOfficeByIdQuery(id), ct);
        return TypedResults.Ok(result);
    }
}
