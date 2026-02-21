namespace FSH.Modules.Library.Features.v1.Employees.GetById;

public sealed class GetEmployeeHandler : IQueryHandler<GetEmployeeQuery, EmployeeDto>
{
    private readonly LibraryDbContext _context;

    public GetEmployeeHandler(LibraryDbContext context)
    {
        _context = context;
    }

    public async ValueTask<EmployeeDto> Handle(GetEmployeeQuery query, CancellationToken ct)
    {
        var employee = await _context.Employees
            .AsNoTracking()
            .Where(e => e.Id == query.Id)
            .Select(e => new EmployeeDto(
                e.Id,
                e.FirstName,
                e.LastName,
                e.Email,
                e.Position,
                e.OfficeId,
                null,
                e.CreatedOnUtc))
            .FirstOrDefaultAsync(ct);

        return employee ?? throw new NotFoundException(nameof(Employee), [query.Id.ToString()]);
    }
}
