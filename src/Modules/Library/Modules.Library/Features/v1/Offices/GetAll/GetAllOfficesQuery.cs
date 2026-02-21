namespace FSH.Modules.Library.Features.v1.Offices.GetAll;

public sealed record GetAllOfficesQuery : IPagedQuery, IQuery<PagedResponse<OfficeDto>>
{
    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public string? Sort { get; set; }
}
