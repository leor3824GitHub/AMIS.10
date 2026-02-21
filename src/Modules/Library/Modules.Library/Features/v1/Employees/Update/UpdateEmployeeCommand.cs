namespace FSH.Modules.Library.Features.v1.Employees.Update;

public sealed record UpdateEmployeeCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Position,
    Guid? OfficeId) : ICommand;
