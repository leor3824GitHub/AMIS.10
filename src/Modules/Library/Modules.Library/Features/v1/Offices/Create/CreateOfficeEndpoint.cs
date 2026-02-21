namespace FSH.Modules.Library.Features.v1.Offices.Create;

public static class CreateOfficeEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPost("/", Handle)
            .WithName(nameof(CreateOfficeCommand))
            .WithSummary("Create a new office")
            .WithDescription("Creates a new office location")
            .RequirePermission(LibraryPermissions.Offices.Create)
            .Produces<Guid>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<IResult> Handle(
        CreateOfficeRequest request,
        IMediator mediator,
        CancellationToken ct)
    {
        var cmd = new CreateOfficeCommand(request.Name, request.Location, request.Code);
        var result = await mediator.Send(cmd, ct);
        return TypedResults.Created($"/api/v1/library/offices/{result}", result);
    }
}
