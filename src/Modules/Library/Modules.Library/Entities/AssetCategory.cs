namespace FSH.Modules.Library.Entities;

/// <summary>
/// Represents an Asset Category in the system.
/// Used for classifying assets across modules.
/// </summary>
public class AssetCategory : BaseEntity<Guid>, IHasTenant, IAuditableEntity
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Code { get; private set; } = default!;
    public string TenantId { get; private set; } = default!;
    public DateTimeOffset CreatedOnUtc { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedOnUtc { get; set; }
    public string? LastModifiedBy { get; set; }

    public static AssetCategory Create(string name, string description, string code, string tenantId)
    {
        var category = new AssetCategory
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Code = code,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
        return category;
    }

    public void Update(string name, string description, string code)
    {
        Name = name;
        Description = description;
        Code = code;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
    }
}
