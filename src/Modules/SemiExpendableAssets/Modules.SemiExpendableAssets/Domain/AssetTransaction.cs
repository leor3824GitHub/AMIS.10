using FSH.Framework.Core.Domain;

namespace FSH.Modules.SemiExpendableAssets.Domain;

/// <summary>Asset transaction audit trail.</summary>
public sealed class AssetTransaction : AuditableAggregateRoot<Guid>
{
    public Guid AssetId { get; private set; }
    public AssetTransactionType TransactionType { get; private set; }
    public string ReferenceNo { get; private set; } = null!;
    public Guid? FromCustodianId { get; private set; }
    public Guid? ToCustodianId { get; private set; }
    public Guid? FromLocationId { get; private set; }
    public Guid? ToLocationId { get; private set; }
    public DateTimeOffset TransactionDate { get; private set; }
    public string? Remarks { get; private set; }

    private AssetTransaction() { }

    /// <summary>Factory method to create a transaction record.</summary>
    public static AssetTransaction Create(
        Guid assetId,
        AssetTransactionType transactionType,
        string referenceNo,
        Guid? fromCustodianId,
        Guid? toCustodianId,
        Guid? fromLocationId,
        Guid? toLocationId,
        string tenantId,
        string? remarks = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(referenceNo);
        ArgumentException.ThrowIfNullOrWhiteSpace(tenantId);

        return new AssetTransaction
        {
            Id = Guid.NewGuid(),
            AssetId = assetId,
            TransactionType = transactionType,
            ReferenceNo = referenceNo,
            FromCustodianId = fromCustodianId,
            ToCustodianId = toCustodianId,
            FromLocationId = fromLocationId,
            ToLocationId = toLocationId,
            TransactionDate = DateTimeOffset.UtcNow,
            Remarks = remarks,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
    }
}
