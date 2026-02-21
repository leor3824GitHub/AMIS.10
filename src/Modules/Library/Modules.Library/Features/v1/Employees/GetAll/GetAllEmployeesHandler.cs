namespace FSH.Modules.Library.Features.v1.Employees.GetAll;

public sealed class GetAllEmployeesHandler(
    LibraryDbContext dbContext) : IQueryHandler<GetAllEmployeesQuery, PagedResponse<EmployeeDto>>
{
    public async ValueTask<PagedResponse<EmployeeDto>> Handle(GetAllEmployeesQuery query, CancellationToken ct)
    {
        var employees = dbContext.Employees.AsNoTracking()
            .OrderBy(e => e.FirstName);

        var dtos = employees.Select(e => new EmployeeDto(
            e.Id,
            e.FirstName,
            e.LastName,
            e.Email,
            e.Position,
            e.OfficeId,
            null,
            e.CreatedOnUtc));

        return await dtos.ToPagedResponseAsync(query, ct);
    }
}
