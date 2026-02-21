using FSH.Framework.Core.Domain;

namespace FSH.Modules.AssetInventory.Domain;

/// <summary>
/// AssetTransaction tracks the audit trail of all asset movements and state changes.
/// </summary>
public class AssetTransaction : AuditableAggregateRoot<Guid>
{
    // Transaction Details
    public Guid AssetId { get; set; }
    public TransactionType TransactionType { get; set; }
    public string ReferenceNo { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly TransactionDate { get; set; }
    public string? Remarks { get; set; }

    // Parties Involved
    public Guid? FromCustodianId { get; set; }
    public Guid? ToCustodianId { get; set; }
    public Guid? FromLocationId { get; set; }
    public Guid? ToLocationId { get; set; }

    // Navigation
    public virtual PhysicalAsset? Asset { get; set; }

    /// <summary>
    /// Factory method to create a new AssetTransaction.
    /// </summary>
    public static AssetTransaction Create(
        Guid assetId,
        TransactionType transactionType,
        string referenceNo,
        DateOnly transactionDate,
        string tenantId,
        string? description = null,
        string? remarks = null,
        Guid? fromCustodianId = null,
        Guid? toCustodianId = null,
        Guid? fromLocationId = null,
        Guid? toLocationId = null)
    {
        return new AssetTransaction
        {
            Id = Guid.NewGuid(),
            AssetId = assetId,
            TransactionType = transactionType,
            ReferenceNo = referenceNo,
            Description = description,
            TransactionDate = transactionDate,
            Remarks = remarks,
            FromCustodianId = fromCustodianId,
            ToCustodianId = toCustodianId,
            FromLocationId = fromLocationId,
            ToLocationId = toLocationId,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };
    }
}
