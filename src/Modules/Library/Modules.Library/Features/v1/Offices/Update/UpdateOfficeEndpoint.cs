namespace FSH.Modules.Library.Features.v1.Offices.Update;

public static class UpdateOfficeEndpoint
{
    public static RouteHandlerBuilder Map(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapPut("/{id}", Handle)
            .WithName(nameof(UpdateOfficeCommand))
            .WithSummary("Update an office")
            .WithDescription("Updates an existing office")
            .RequirePermission(LibraryPermissions.Offices.Update)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest);

    private static async Task<IResult> Handle(
        Guid id,
        UpdateOfficeRequest request,
        IMediator mediator,
        CancellationToken ct)
    {
        var cmd = new UpdateOfficeCommand(id, request.Name, request.Location, request.Code);
        await mediator.Send(cmd, ct);
        return TypedResults.NoContent();
    }
}
