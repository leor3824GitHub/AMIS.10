namespace FSH.Modules.Library.Features.v1.Employees.Create;

public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    string Position,
    Guid? OfficeId) : ICommand<Guid>;
