using FSH.Framework.Core.Domain;

namespace FSH.Modules.SemiExpendableAssets.Domain;

/// <summary>Receipt for incoming stock (RIS/DR/Purchase).</summary>
public sealed class Receipt : AuditableAggregateRoot<Guid>
{
    public string ReceiptNumber { get; private set; } = null!;
    public string ReceiptType { get; private set; } = null!; // RIS, DR, PO, etc.
    public DateTimeOffset ReceiptDate { get; private set; }
    public Guid? SupplierId { get; private set; }
    public string? DeliveryReferenceNo { get; private set; }
    public string? Remarks { get; private set; }

    private readonly List<ReceiptItem> _items = [];
    public IReadOnlyList<ReceiptItem> Items => _items.AsReadOnly();

    private Receipt() { }

    public static Receipt Create(string receiptNumber, string receiptType, DateTimeOffset receiptDate, string tenantId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(receiptNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(receiptType);
        ArgumentException.ThrowIfNullOrWhiteSpace(tenantId);

        return new Receipt
        {
            Id = Guid.NewGuid(),
            ReceiptNumber = receiptNumber,
            ReceiptType = receiptType,
            ReceiptDate = receiptDate,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
    }

    public void AddItem(string description, string category, int quantity, decimal unitCost, AssetCondition condition = AssetCondition.New)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(unitCost);

        var item = ReceiptItem.Create(Id, description, category, quantity, unitCost, condition);
        _items.Add(item);
    }
}

/// <summary>Line item in a receipt.</summary>
public sealed class ReceiptItem : BaseEntity<Guid>
{
    public Guid ReceiptId { get; private set; }
    public string Description { get; private set; } = null!;
    public string Category { get; private set; } = null!;
    public int Quantity { get; private set; }
    public decimal UnitCost { get; private set; }
    public AssetCondition Condition { get; private set; } = AssetCondition.New;

    private ReceiptItem() { }

    public static ReceiptItem Create(Guid receiptId, string description, string category, int quantity, decimal unitCost, AssetCondition condition = AssetCondition.New)
    {
        return new ReceiptItem
        {
            Id = Guid.NewGuid(),
            ReceiptId = receiptId,
            Description = description,
            Category = category,
            Quantity = quantity,
            UnitCost = unitCost,
            Condition = condition
        };
    }
}
