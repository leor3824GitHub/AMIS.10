namespace FSH.Modules.Library.Features.v1.Employees.GetById;

public sealed record GetEmployeeByIdQuery(Guid Id) : IQuery<EmployeeDto>;
