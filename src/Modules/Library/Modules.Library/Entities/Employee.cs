namespace FSH.Modules.Library.Entities;

/// <summary>
/// Represents an Employee in the system.
/// Used as reference data across multiple modules.
/// </summary>
public class Employee : BaseEntity<Guid>, IHasTenant, IAuditableEntity
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Position { get; private set; } = default!;
    public Guid? OfficeId { get; private set; }
    public string TenantId { get; private set; } = default!;
    public DateTimeOffset CreatedOnUtc { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedOnUtc { get; set; }
    public string? LastModifiedBy { get; set; }

    public static Employee Create(string firstName, string lastName, string email, string position, string tenantId, Guid? officeId)
    {
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Position = position,
            TenantId = tenantId,
            OfficeId = officeId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
        return employee;
    }

    public void Update(string firstName, string lastName, string position, Guid? officeId)
    {
        FirstName = firstName;
        LastName = lastName;
        Position = position;
        OfficeId = officeId;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
    }
}
