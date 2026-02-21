using FSH.Framework.Core.Domain;

namespace FSH.Modules.AssetInventory.Domain;

/// <summary>
/// PPEIR (PPE Issuance/Return Record) aggregate root.
/// Represents a transfer, sale, or disposal record.
/// </summary>
public class PPEIR : AuditableAggregateRoot<Guid>
{
    // PPEIR Details
    public string ReferenceNumber { get; private set; } = null!;
    public TransactionType TransactionType { get; private set; }
    public DateOnly TransactionDate { get; private set; }
    public string? Description { get; private set; }
    public string Status { get; private set; } = "Draft";

    // Parties Involved
    public Guid? FromEmployeeId { get; private set; }
    public Guid? ToEmployeeId { get; private set; }
    public Guid? FromLocationId { get; private set; }
    public Guid? ToLocationId { get; private set; }

    // Navigation Properties
    public virtual ICollection<PPEIRItem> Items { get; private set; } = new List<PPEIRItem>();

    /// <summary>
    /// Factory method to create a new PPEIR.
    /// </summary>
    public static PPEIR Create(
        string referenceNumber,
        TransactionType transactionType,
        DateOnly transactionDate,
        string tenantId,
        string? description = null,
        Guid? fromEmployeeId = null,
        Guid? toEmployeeId = null,
        Guid? fromLocationId = null,
        Guid? toLocationId = null)
    {
        var ppeir = new PPEIR
        {
            Id = Guid.NewGuid(),
            ReferenceNumber = referenceNumber,
            TransactionType = transactionType,
            TransactionDate = transactionDate,
            Description = description,
            FromEmployeeId = fromEmployeeId,
            ToEmployeeId = toEmployeeId,
            FromLocationId = fromLocationId,
            ToLocationId = toLocationId,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };

        return ppeir;
    }

    /// <summary>
    /// Adds an item to the PPEIR.
    /// </summary>
    public void AddItem(Guid assetId, string addedBy)
    {
        var item = PPEIRItem.Create(Id, assetId);
        Items.Add(item);
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = addedBy;
    }

    /// <summary>
    /// Marks PPEIR as processed.
    /// </summary>
    public void Process(string processedBy)
    {
        if (Status != "Draft")
            return;

        Status = "Processed";
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = processedBy;
    }
}

/// <summary>
/// PPEIR line item.
/// </summary>
public class PPEIRItem : BaseEntity<Guid>
{
    public Guid PPEIRId { get; private set; }
    public Guid AssetId { get; private set; }

    public virtual PPEIR? PPEIR { get; private set; }
    public virtual PhysicalAsset? Asset { get; private set; }

    /// <summary>
    /// Factory method to create a new PPEIR item.
    /// </summary>
    public static PPEIRItem Create(Guid ppeirId, Guid assetId)
    {
        return new PPEIRItem
        {
            Id = Guid.NewGuid(),
            PPEIRId = ppeirId,
            AssetId = assetId
        };
    }
}
