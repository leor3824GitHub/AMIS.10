namespace FSH.Modules.Library.Features.v1.Offices.Create;

public sealed record CreateOfficeCommand(
    string Name,
    string Location,
    string Code) : ICommand<Guid>;
