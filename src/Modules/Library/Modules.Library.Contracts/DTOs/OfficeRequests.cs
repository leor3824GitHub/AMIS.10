namespace FSH.Modules.Library.Contracts.DTOs;

public sealed record CreateOfficeRequest(
    string Name,
    string Location,
    string Code);

public sealed record UpdateOfficeRequest(
    string Name,
    string Location,
    string Code);

public sealed record CreateOfficeResponse(Guid Id);
