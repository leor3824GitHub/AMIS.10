namespace FSH.Modules.Library.Features.v1.Employees.GetById;

public sealed class GetEmployeeByIdHandler(
    LibraryDbContext dbContext) : IQueryHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    public async ValueTask<EmployeeDto> Handle(GetEmployeeByIdQuery query, CancellationToken ct)
    {
        var employee = await dbContext.Employees.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == query.Id, ct)
            ?? throw new NotFoundException($"Employee with id {query.Id} not found");

        return new EmployeeDto(
            employee.Id,
            employee.FirstName,
            employee.LastName,
            employee.Email,
            employee.Position,
            employee.OfficeId,
            null,
            employee.CreatedOnUtc);
    }
}
