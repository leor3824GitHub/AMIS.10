namespace FSH.Modules.Library.Entities;

/// <summary>
/// Represents an Office/Location in the system.
/// Used as reference data across multiple modules.
/// </summary>
public class Office : BaseEntity<Guid>, IHasTenant, IAuditableEntity
{
    public string Name { get; private set; } = default!;
    public string Location { get; private set; } = default!;
    public string Code { get; private set; } = default!;
    public string TenantId { get; private set; } = default!;
    public DateTimeOffset CreatedOnUtc { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedOnUtc { get; set; }
    public string? LastModifiedBy { get; set; }

    public static Office Create(string name, string location, string code, string tenantId)
    {
        var office = new Office
        {
            Id = Guid.NewGuid(),
            Name = name,
            Location = location,
            Code = code,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
        return office;
    }

    public void Update(string name, string location, string code)
    {
        Name = name;
        Location = location;
        Code = code;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
    }
}
