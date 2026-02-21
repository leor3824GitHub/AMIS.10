using FSH.Framework.Core.Domain;

namespace FSH.Modules.AssetInventory.Domain;

/// <summary>
/// RRP (Return Receipt of Property) aggregate root.
/// Represents a return receipt document for PPE assets.
/// </summary>
public class RRP : AuditableAggregateRoot<Guid>
{
    // RRP Details
    public string ReceiptNumber { get; private set; } = null!;
    public DateOnly ReceiptDate { get; private set; }
    public Guid EmployeeId { get; private set; }
    public string? Description { get; private set; }
    public string Status { get; private set; } = "Draft";

    // Navigation Properties
    public virtual ICollection<RRPItem> Items { get; private set; } = new List<RRPItem>();

    /// <summary>
    /// Factory method to create a new RRP.
    /// </summary>
    public static RRP Create(
        string receiptNumber,
        DateOnly receiptDate,
        Guid employeeId,
        string tenantId,
        string? description = null)
    {
        var rrp = new RRP
        {
            Id = Guid.NewGuid(),
            ReceiptNumber = receiptNumber,
            ReceiptDate = receiptDate,
            EmployeeId = employeeId,
            Description = description,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };

        return rrp;
    }

    /// <summary>
    /// Adds an item to the RRP.
    /// </summary>
    public void AddItem(Guid assetId, string addedBy)
    {
        var item = RRPItem.Create(Id, assetId);
        Items.Add(item);
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = addedBy;
    }

    /// <summary>
    /// Marks RRP as received.
    /// </summary>
    public void Receive(string receivedBy)
    {
        if (Status != "Draft")
            return;

        Status = "Received";
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = receivedBy;
    }
}

/// <summary>
/// RRP line item.
/// </summary>
public class RRPItem : BaseEntity<Guid>
{
    public Guid RRPId { get; private set; }
    public Guid AssetId { get; private set; }

    public virtual RRP? RRP { get; private set; }
    public virtual PhysicalAsset? Asset { get; private set; }

    /// <summary>
    /// Factory method to create a new RRP item.
    /// </summary>
    public static RRPItem Create(Guid rrpId, Guid assetId)
    {
        return new RRPItem
        {
            Id = Guid.NewGuid(),
            RRPId = rrpId,
            AssetId = assetId
        };
    }
}
