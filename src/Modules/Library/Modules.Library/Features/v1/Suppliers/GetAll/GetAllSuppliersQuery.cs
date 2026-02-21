namespace FSH.Modules.Library.Features.v1.Suppliers.GetAll;

public sealed record GetAllSuppliersQuery : IPagedQuery, IQuery<PagedResponse<SupplierDto>>
{
    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public string? Sort { get; set; }
}
