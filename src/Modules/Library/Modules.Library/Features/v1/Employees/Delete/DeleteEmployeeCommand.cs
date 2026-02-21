namespace FSH.Modules.Library.Features.v1.Employees.Delete;

public sealed record DeleteEmployeeCommand(Guid Id) : ICommand;
