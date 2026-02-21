namespace FSH.Modules.Library.Contracts.DTOs;

/// <summary>
/// Data Transfer Object for Employee.
/// </summary>
public record EmployeeDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Position,
    Guid? OfficeId,
    string? OfficeName,
    DateTimeOffset CreatedAtUtc);
