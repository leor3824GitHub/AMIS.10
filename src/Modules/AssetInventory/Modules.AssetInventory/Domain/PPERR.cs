using FSH.Framework.Core.Domain;

namespace FSH.Modules.AssetInventory.Domain;

/// <summary>
/// PPERR (Property and Equipment Receipt) aggregate root.
/// Represents a receipt document for PPE assets.
/// </summary>
public class PPERR : AuditableAggregateRoot<Guid>
{
    // Receipt Details
    public string ReceiptNumber { get; private set; } = null!;
    public DateOnly ReceiptDate { get; private set; }
    public Guid? SupplierId { get; private set; }
    public string? Description { get; private set; }
    public string Status { get; private set; } = "Draft";

    // Navigation Properties
    public virtual ICollection<PPERRItem> Items { get; private set; } = new List<PPERRItem>();

    /// <summary>
    /// Factory method to create a new PPERR.
    /// </summary>
    public static PPERR Create(
        string receiptNumber,
        DateOnly receiptDate,
        string tenantId,
        Guid? supplierId = null,
        string? description = null)
    {
        var receipt = new PPERR
        {
            Id = Guid.NewGuid(),
            ReceiptNumber = receiptNumber,
            ReceiptDate = receiptDate,
            SupplierId = supplierId,
            Description = description,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };

        return receipt;
    }

    /// <summary>
    /// Adds an item to the receipt.
    /// </summary>
    public void AddItem(Guid assetId, int quantity, string addedBy)
    {
        var item = PPERRItem.Create(Id, assetId, quantity);
        Items.Add(item);
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = addedBy;
    }

    /// <summary>
    /// Marks receipt as finalized.
    /// </summary>
    public void Finalize(string finalizedBy)
    {
        if (Status != "Draft")
            return;

        Status = "Finalized";
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = finalizedBy;
    }
}

/// <summary>
/// PPERR line item.
/// </summary>
public class PPERRItem : BaseEntity<Guid>
{
    public Guid PPERRId { get; private set; }
    public Guid AssetId { get; private set; }
    public int Quantity { get; private set; }

    public virtual PPERR? PPERR { get; private set; }
    public virtual PhysicalAsset? Asset { get; private set; }

    /// <summary>
    /// Factory method to create a new PPERR item.
    /// </summary>
    public static PPERRItem Create(Guid pperrId, Guid assetId, int quantity)
    {
        return new PPERRItem
        {
            Id = Guid.NewGuid(),
            PPERRId = pperrId,
            AssetId = assetId,
            Quantity = quantity
        };
    }
}
