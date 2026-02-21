namespace FSH.Framework.Core.Domain;

/// <summary>
/// Base class for aggregate roots with built-in multi-tenancy, auditing, and soft-delete support.
/// Combines AggregateRoot with IHasTenant, IAuditableEntity, and ISoftDeletable.
/// </summary>
/// <typeparam name="TId">The type of the aggregate identifier.</typeparam>
public abstract class AuditableAggregateRoot<TId> : AggregateRoot<TId>, IHasTenant, IAuditableEntity, ISoftDeletable
{
    /// <summary>
    /// Gets or sets the tenant identifier for multi-tenancy support.
    /// </summary>
    public string TenantId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the UTC timestamp when the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the creator.
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp when the entity was last modified.
    /// </summary>
    public DateTimeOffset? LastModifiedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the last modifier.
    /// </summary>
    public string? LastModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is deleted (soft delete).
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp when the entity was deleted.
    /// </summary>
    public DateTimeOffset? DeletedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who deleted the entity.
    /// </summary>
    public string? DeletedBy { get; set; }
}
