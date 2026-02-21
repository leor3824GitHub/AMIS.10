namespace FSH.Modules.Library.Entities;

/// <summary>
/// Represents a Supplier in the system.
/// Used as reference data for asset acquisition.
/// </summary>
public class Supplier : BaseEntity<Guid>, IHasTenant, IAuditableEntity
{
    public string Name { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public string TIN { get; private set; } = default!;
    public string ContactPerson { get; private set; } = default!;
    public string TenantId { get; private set; } = default!;
    public DateTimeOffset CreatedOnUtc { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedOnUtc { get; set; }
    public string? LastModifiedBy { get; set; }

    public static Supplier Create(string name, string address, string tin, string contactPerson, string tenantId)
    {
        var supplier = new Supplier
        {
            Id = Guid.NewGuid(),
            Name = name,
            Address = address,
            TIN = tin,
            ContactPerson = contactPerson,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
        return supplier;
    }

    public void Update(string name, string address, string tin, string contactPerson)
    {
        Name = name;
        Address = address;
        TIN = tin;
        ContactPerson = contactPerson;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
    }
}
