namespace FSH.Modules.Library.Features.v1.Suppliers.Update;

public sealed record UpdateSupplierCommand(
    Guid Id,
    string Name,
    string Address,
    string TIN,
    string ContactPerson) : ICommand;
