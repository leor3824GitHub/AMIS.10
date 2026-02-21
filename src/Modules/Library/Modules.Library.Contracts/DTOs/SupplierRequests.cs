namespace FSH.Modules.Library.Contracts.DTOs;

public sealed record CreateSupplierRequest(
    string Name,
    string Address,
    string TIN,
    string ContactPerson);

public sealed record UpdateSupplierRequest(
    string Name,
    string Address,
    string TIN,
    string ContactPerson);

public sealed record CreateSupplierResponse(Guid Id);
