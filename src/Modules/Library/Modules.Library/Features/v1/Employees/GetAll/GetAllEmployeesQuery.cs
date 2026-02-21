namespace FSH.Modules.Library.Features.v1.Employees.GetAll;

public sealed record GetAllEmployeesQuery : IPagedQuery, IQuery<PagedResponse<EmployeeDto>>
{
    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public string? Sort { get; set; }
}
