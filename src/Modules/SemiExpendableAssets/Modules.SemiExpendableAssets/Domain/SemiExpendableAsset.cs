using FSH.Framework.Core.Domain;
using FSH.Modules.SemiExpendableAssets.Domain.Events;

namespace FSH.Modules.SemiExpendableAssets.Domain;

/// <summary>Semi-expendable asset aggregate root.</summary>
public class SemiExpendableAsset : AuditableAggregateRoot<Guid>
{
    // Asset identification and description
    public string ICSNumber { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string Category { get; private set; } = null!;

    // Acquisition information
    public DateTimeOffset AcquisitionDate { get; private set; }
    public decimal AcquisitionCost { get; private set; }

    // Status tracking
    public AssetCondition Condition { get; private set; } = AssetCondition.New;
    public AssetStatus Status { get; private set; } = AssetStatus.Active;

    // Custodian and location information
    public Guid? CurrentCustodianId { get; private set; }
    public Guid? CurrentLocationId { get; private set; }

    // Reference documents
    public Guid? ReceiptReferenceId { get; private set; }

    private SemiExpendableAsset() { }

    /// <summary>Factory method to create a new semi-expendable asset.</summary>
    public static SemiExpendableAsset Create(
        string icsNumber,
        string description,
        string category,
        DateTimeOffset acquisitionDate,
        decimal acquisitionCost,
        string tenantId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(icsNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(category);
        ArgumentException.ThrowIfNullOrWhiteSpace(tenantId);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(acquisitionCost);

        var asset = new SemiExpendableAsset
        {
            Id = Guid.NewGuid(),
            ICSNumber = icsNumber,
            Description = description,
            Category = category,
            AcquisitionDate = acquisitionDate,
            AcquisitionCost = acquisitionCost,
            TenantId = tenantId,
            CreatedOnUtc = DateTimeOffset.UtcNow,
            Condition = AssetCondition.New,
            Status = AssetStatus.Active
        };

        asset.AddDomainEvent(SemiExpendableAssetCreatedEvent.Create(asset.Id, icsNumber, description, tenantId));
        return asset;
    }

    /// <summary>Issue the asset to a custodian at a location.</summary>
    public void IssueAsset(Guid custodianId, Guid locationId, string? remarks = null)
    {
        if (Status != AssetStatus.Active)
            throw new InvalidOperationException($"Cannot issue asset with status {Status}");

        CurrentCustodianId = custodianId;
        CurrentLocationId = locationId;
        Status = AssetStatus.Issued;

        AddDomainEvent(AssetIssuedEvent.Create(Id, ICSNumber, custodianId, locationId, remarks, TenantId));
    }

    /// <summary>Return the asset from a custodian.</summary>
    public void ReturnAsset(Guid fromCustodianId, Guid toLocationId, string? remarks = null)
    {
        if (Status != AssetStatus.Issued)
            throw new InvalidOperationException($"Cannot return asset with status {Status}");

        if (CurrentCustodianId != fromCustodianId)
            throw new InvalidOperationException("Asset is not with the specified custodian");

        CurrentCustodianId = null;
        CurrentLocationId = toLocationId;
        Status = AssetStatus.Returned;

        AddDomainEvent(AssetReturnedEvent.Create(Id, ICSNumber, fromCustodianId, toLocationId, remarks, TenantId));
    }

    /// <summary>Transfer the asset to another custodian.</summary>
    public void TransferAsset(Guid fromCustodianId, Guid toCustodianId, Guid toLocationId, string? remarks = null)
    {
        if (Status != AssetStatus.Issued)
            throw new InvalidOperationException($"Cannot transfer asset with status {Status}");

        if (CurrentCustodianId != fromCustodianId)
            throw new InvalidOperationException("Asset is not with the specified custodian");

        CurrentCustodianId = toCustodianId;
        CurrentLocationId = toLocationId;

        AddDomainEvent(AssetTransferredEvent.Create(Id, ICSNumber, fromCustodianId, toCustodianId, toLocationId, remarks, TenantId));
    }

    /// <summary>Dispose of the asset.</summary>
    public void DisposeAsset(string? remarks = null)
    {
        Status = AssetStatus.Disposed;
        CurrentCustodianId = null;

        AddDomainEvent(AssetDisposedEvent.Create(Id, ICSNumber, remarks, TenantId));
    }

    /// <summary>Update the asset details.</summary>
    public void UpdateDetails(string description, string category, AssetCondition condition)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(category);

        Description = description;
        Category = category;
        Condition = condition;

        AddDomainEvent(AssetDetailsUpdatedEvent.Create(Id, ICSNumber, TenantId));
    }

    /// <summary>Update core asset information.</summary>
    public void Update(
        string icsNumber,
        string description,
        string category,
        DateTimeOffset acquisitionDate,
        decimal acquisitionCost,
        string updatedBy)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(icsNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(category);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(acquisitionCost);

        ICSNumber = icsNumber;
        Description = description;
        Category = category;
        AcquisitionDate = acquisitionDate;
        AcquisitionCost = acquisitionCost;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = updatedBy;
    }
}
