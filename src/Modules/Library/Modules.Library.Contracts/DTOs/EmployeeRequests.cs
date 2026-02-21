namespace FSH.Modules.Library.Contracts.DTOs;

public sealed record CreateEmployeeRequest(
    string FirstName,
    string LastName,
    string Email,
    string Position,
    Guid? OfficeId);

public sealed record UpdateEmployeeRequest(
    string FirstName,
    string LastName,
    string Position,
    Guid? OfficeId);

public sealed record CreateEmployeeResponse(Guid Id);
