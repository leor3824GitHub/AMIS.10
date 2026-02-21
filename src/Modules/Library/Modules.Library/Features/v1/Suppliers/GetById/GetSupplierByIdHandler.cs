namespace FSH.Modules.Library.Features.v1.Suppliers.GetById;

public sealed class GetSupplierByIdHandler(
    LibraryDbContext dbContext) : IQueryHandler<GetSupplierByIdQuery, SupplierDto>
{
    public async ValueTask<SupplierDto> Handle(GetSupplierByIdQuery query, CancellationToken ct)
    {
        var supplier = await dbContext.Suppliers.AsNoTracking()
            .Where(x => x.Id == query.Id)
            .Select(x => new SupplierDto(x.Id, x.Name, x.Address, x.TIN, x.ContactPerson, x.CreatedOnUtc))
            .FirstOrDefaultAsync(ct) ?? throw new NotFoundException($"Supplier with id {query.Id} not found");

        return supplier;
    }
}
