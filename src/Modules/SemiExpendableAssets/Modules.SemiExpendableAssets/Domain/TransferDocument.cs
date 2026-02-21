using FSH.Framework.Core.Domain;

namespace FSH.Modules.SemiExpendableAssets.Domain;

/// <summary>Document for asset transfers or disposal.</summary>
public sealed class TransferDocument : AuditableAggregateRoot<Guid>
{
    public string TransferDocumentNumber { get; private set; } = null!;
    public DateTimeOffset TransferDate { get; private set; }
    public Guid FromCustodianId { get; private set; }
    public Guid? ToCustodianId { get; private set; } // Null if disposal
    public Guid? ToLocationId { get; private set; }
    public string TransferType { get; private set; } = null!; // Transfer or Disposal
    public string? Reason { get; private set; }
    public string? Remarks { get; private set; }

    private readonly List<TransferItem> _items = [];
    public IReadOnlyList<TransferItem> Items => _items.AsReadOnly();

    private TransferDocument() { }

    public static TransferDocument Create(
        string transferDocumentNumber,
        DateTimeOffset transferDate,
        Guid fromCustodianId,
        string transferType,
        string tenantId,
        Guid? toCustodianId = null,
        Guid? toLocationId = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(transferDocumentNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(transferType);
        ArgumentException.ThrowIfNullOrWhiteSpace(tenantId);

        return new TransferDocument
        {
            Id = Guid.NewGuid(),
            TransferDocumentNumber = transferDocumentNumber,
            TransferDate = transferDate,
            FromCustodianId = fromCustodianId,
            ToCustodianId = toCustodianId,
            ToLocationId = toLocationId,
            TransferType = transferType,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
    }

    public void AddItem(Guid assetId, string? remarks = null)
    {
        var item = TransferItem.Create(Id, assetId, remarks);
        _items.Add(item);
    }
}

/// <summary>Line item in a transfer document.</summary>
public sealed class TransferItem : BaseEntity<Guid>
{
    public Guid TransferDocumentId { get; private set; }
    public Guid AssetId { get; private set; }
    public string? Remarks { get; private set; }

    private TransferItem() { }

    public static TransferItem Create(Guid transferDocumentId, Guid assetId, string? remarks = null)
    {
        return new TransferItem
        {
            Id = Guid.NewGuid(),
            TransferDocumentId = transferDocumentId,
            AssetId = assetId,
            Remarks = remarks
        };
    }
}
