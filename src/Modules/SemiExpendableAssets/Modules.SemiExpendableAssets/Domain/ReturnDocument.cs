using FSH.Framework.Core.Domain;

namespace FSH.Modules.SemiExpendableAssets.Domain;

/// <summary>Document for returned assets.</summary>
public sealed class ReturnDocument : AuditableAggregateRoot<Guid>
{
    public string ReturnDocumentNumber { get; private set; } = null!;
    public DateTimeOffset ReturnDate { get; private set; }
    public Guid FromCustodianId { get; private set; }
    public Guid ToLocationId { get; private set; }
    public string? Reason { get; private set; }
    public string? Remarks { get; private set; }

    private readonly List<ReturnItem> _items = [];
    public IReadOnlyList<ReturnItem> Items => _items.AsReadOnly();

    private ReturnDocument() { }

    public static ReturnDocument Create(string returnDocumentNumber, DateTimeOffset returnDate, Guid fromCustodianId, Guid toLocationId, string tenantId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(returnDocumentNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(tenantId);

        return new ReturnDocument
        {
            Id = Guid.NewGuid(),
            ReturnDocumentNumber = returnDocumentNumber,
            ReturnDate = returnDate,
            FromCustodianId = fromCustodianId,
            ToLocationId = toLocationId,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
    }

    public void AddItem(Guid assetId, string? remarks = null)
    {
        var item = ReturnItem.Create(Id, assetId, remarks);
        _items.Add(item);
    }
}

/// <summary>Line item in a return document.</summary>
public sealed class ReturnItem : BaseEntity<Guid>
{
    public Guid ReturnDocumentId { get; private set; }
    public Guid AssetId { get; private set; }
    public string? Remarks { get; private set; }

    private ReturnItem() { }

    public static ReturnItem Create(Guid returnDocumentId, Guid assetId, string? remarks = null)
    {
        return new ReturnItem
        {
            Id = Guid.NewGuid(),
            ReturnDocumentId = returnDocumentId,
            AssetId = assetId,
            Remarks = remarks
        };
    }
}
