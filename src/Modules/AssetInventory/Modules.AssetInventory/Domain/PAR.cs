using FSH.Framework.Core.Domain;

namespace FSH.Modules.AssetInventory.Domain;

/// <summary>
/// PAR (Property Acknowledgment Receipt) aggregate root.
/// Represents an acknowledgment of receipt by an employee.
/// </summary>
public class PAR : AuditableAggregateRoot<Guid>
{
    // PAR Details
    public string ReceiptNumber { get; private set; } = null!;
    public DateOnly ReceiptDate { get; private set; }
    public Guid EmployeeId { get; private set; }
    public string? Description { get; private set; }
    public string Status { get; private set; } = "Draft";

    // Navigation Properties
    public virtual ICollection<PARItem> Items { get; private set; } = new List<PARItem>();

    /// <summary>
    /// Factory method to create a new PAR.
    /// </summary>
    public static PAR Create(
        string receiptNumber,
        DateOnly receiptDate,
        Guid employeeId,
        string tenantId,
        string? description = null)
    {
        var par = new PAR
        {
            Id = Guid.NewGuid(),
            ReceiptNumber = receiptNumber,
            ReceiptDate = receiptDate,
            EmployeeId = employeeId,
            Description = description,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };

        return par;
    }

    /// <summary>
    /// Adds an item to the PAR.
    /// </summary>
    public void AddItem(Guid assetId, string addedBy)
    {
        var item = PARItem.Create(Id, assetId);
        Items.Add(item);
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = addedBy;
    }

    /// <summary>
    /// Marks PAR as acknowledged.
    /// </summary>
    public void Acknowledge(string acknowledgedBy)
    {
        if (Status != "Draft")
            return;

        Status = "Acknowledged";
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = acknowledgedBy;
    }
}

/// <summary>
/// PAR line item.
/// </summary>
public class PARItem : BaseEntity<Guid>
{
    public Guid PARId { get; private set; }
    public Guid AssetId { get; private set; }

    public virtual PAR? PAR { get; private set; }
    public virtual PhysicalAsset? Asset { get; private set; }

    /// <summary>
    /// Factory method to create a new PAR item.
    /// </summary>
    public static PARItem Create(Guid parId, Guid assetId)
    {
        return new PARItem
        {
            Id = Guid.NewGuid(),
            PARId = parId,
            AssetId = assetId
        };
    }
}
