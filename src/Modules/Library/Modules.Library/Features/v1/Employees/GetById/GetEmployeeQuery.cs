namespace FSH.Modules.Library.Features.v1.Employees.GetById;

public sealed record GetEmployeeQuery(Guid Id) : IQuery<EmployeeDto>;
