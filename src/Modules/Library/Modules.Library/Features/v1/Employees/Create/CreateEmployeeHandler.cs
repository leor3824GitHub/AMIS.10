namespace FSH.Modules.Library.Features.v1.Employees.Create;

public sealed class CreateEmployeeHandler : ICommandHandler<CreateEmployeeCommand, Guid>
{
    private readonly LibraryDbContext _dbContext;
    private readonly IMultiTenantContextAccessor<AppTenantInfo> _multiTenantContextAccessor;

    public CreateEmployeeHandler(LibraryDbContext dbContext, IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor)
    {
        _dbContext = dbContext;
        _multiTenantContextAccessor = multiTenantContextAccessor;
    }

    public async ValueTask<Guid> Handle(CreateEmployeeCommand cmd, CancellationToken ct)
    {
        var tenantId = _multiTenantContextAccessor.MultiTenantContext?.TenantInfo?.Id
            ?? throw new InvalidOperationException("No tenant context available");

        var employee = Employee.Create(
            cmd.FirstName,
            cmd.LastName,
            cmd.Email,
            cmd.Position,
            tenantId,
            cmd.OfficeId);

        _dbContext.Employees.Add(employee);
        await _dbContext.SaveChangesAsync(ct);
        return employee.Id;
    }
}
