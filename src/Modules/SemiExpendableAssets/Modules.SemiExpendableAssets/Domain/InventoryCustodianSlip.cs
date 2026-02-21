using FSH.Framework.Core.Domain;

namespace FSH.Modules.SemiExpendableAssets.Domain;

/// <summary>Inventory Custodian Slip (ICS) for asset accountability.</summary>
public sealed class InventoryCustodianSlip : AuditableAggregateRoot<Guid>
{
    public string ICSNumber { get; private set; } = null!;
    public DateTimeOffset ICSDate { get; private set; }
    public Guid CustodianId { get; private set; }
    public Guid LocationId { get; private set; }
    public string? Purpose { get; private set; }
    public string? Remarks { get; private set; }

    private readonly List<ICSItem> _items = [];
    public IReadOnlyList<ICSItem> Items => _items.AsReadOnly();

    private InventoryCustodianSlip() { }

    public static InventoryCustodianSlip Create(string icsNumber, DateTimeOffset icsDate, Guid custodianId, Guid locationId, string tenantId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(icsNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(tenantId);

        return new InventoryCustodianSlip
        {
            Id = Guid.NewGuid(),
            ICSNumber = icsNumber,
            ICSDate = icsDate,
            CustodianId = custodianId,
            LocationId = locationId,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
    }

    public void AddItem(Guid assetId)
    {
        var item = ICSItem.Create(Id, assetId);
        _items.Add(item);
    }
}

/// <summary>Line item in an ICS.</summary>
public sealed class ICSItem : BaseEntity<Guid>
{
    public Guid ICSId { get; private set; }
    public Guid AssetId { get; private set; }
    public string? Remarks { get; private set; }

    private ICSItem() { }

    public static ICSItem Create(Guid icsId, Guid assetId)
    {
        return new ICSItem
        {
            Id = Guid.NewGuid(),
            ICSId = icsId,
            AssetId = assetId
        };
    }
}
