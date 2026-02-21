namespace FSH.Modules.Library.Features.v1.Suppliers.Create;

public sealed record CreateSupplierCommand(
    string Name,
    string Address,
    string TIN,
    string ContactPerson) : ICommand<Guid>;
