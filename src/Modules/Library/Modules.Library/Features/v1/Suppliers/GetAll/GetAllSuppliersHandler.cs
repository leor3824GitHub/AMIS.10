namespace FSH.Modules.Library.Features.v1.Suppliers.GetAll;

public sealed class GetAllSuppliersHandler(
    LibraryDbContext dbContext) : IQueryHandler<GetAllSuppliersQuery, PagedResponse<SupplierDto>>
{
    public async ValueTask<PagedResponse<SupplierDto>> Handle(GetAllSuppliersQuery query, CancellationToken ct)
    {
        var suppliers = dbContext.Suppliers.AsNoTracking()
            .OrderBy(s => s.Name);

        var dtos = suppliers.Select(s => new SupplierDto(
            s.Id, s.Name, s.Address, s.TIN, s.ContactPerson, s.CreatedOnUtc));

        return await dtos.ToPagedResponseAsync(query, ct);
    }
}
