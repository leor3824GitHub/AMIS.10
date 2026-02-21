namespace FSH.Modules.Library.Features.v1.Offices.Update;

public sealed record UpdateOfficeCommand(
    Guid Id,
    string Name,
    string Location,
    string Code) : ICommand;
