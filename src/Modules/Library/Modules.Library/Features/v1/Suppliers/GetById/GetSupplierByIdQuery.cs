namespace FSH.Modules.Library.Features.v1.Suppliers.GetById;

public sealed record GetSupplierByIdQuery(Guid Id) : IQuery<SupplierDto>;
