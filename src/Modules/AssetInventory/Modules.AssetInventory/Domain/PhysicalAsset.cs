using FSH.Framework.Core.Domain;
using FSH.Modules.AssetInventory.Domain.Events;

namespace FSH.Modules.AssetInventory.Domain;

/// <summary>
/// PhysicalAsset aggregate root representing a PPE asset in the inventory system.
/// Implements multi-tenancy, auditing, soft-delete, and domain events.
/// </summary>
public class PhysicalAsset : AuditableAggregateRoot<Guid>
{
    // Asset Properties
    public string PropertyNumber { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string Category { get; private set; } = null!;
    public DateOnly AcquisitionDate { get; private set; }
    public decimal AcquisitionCost { get; private set; }
    public int UsefulLifeDays { get; private set; }
    public decimal ResidualValue { get; private set; }
    public AssetCondition Condition { get; private set; }
    public AssetStatus Status { get; private set; }

    // Foreign Keys
    public Guid? CurrentCustodianId { get; private set; }
    public Guid? CurrentLocationId { get; private set; }
    public Guid? SupplierId { get; private set; }

    // Navigation Properties
    public virtual ICollection<AssetTransaction> Transactions { get; private set; } = new List<AssetTransaction>();

    /// <summary>
    /// Factory method to create a new PhysicalAsset.
    /// </summary>
    public static PhysicalAsset Create(
        string propertyNumber,
        string description,
        string category,
        DateOnly acquisitionDate,
        decimal acquisitionCost,
        int usefulLifeDays,
        decimal residualValue,
        AssetCondition condition,
        AssetStatus status,
        string tenantId,
        Guid? currentCustodianId = null,
        Guid? currentLocationId = null,
        Guid? supplierId = null)
    {
        var asset = new PhysicalAsset
        {
            Id = Guid.NewGuid(),
            PropertyNumber = propertyNumber,
            Description = description,
            Category = category,
            AcquisitionDate = acquisitionDate,
            AcquisitionCost = acquisitionCost,
            UsefulLifeDays = usefulLifeDays,
            ResidualValue = residualValue,
            Condition = condition,
            Status = status,
            TenantId = tenantId,
            CurrentCustodianId = currentCustodianId,
            CurrentLocationId = currentLocationId,
            SupplierId = supplierId,
            CreatedOnUtc = DateTimeOffset.UtcNow
        };

        asset.AddDomainEvent(PhysicalAssetCreatedEvent.Create(
            assetId: asset.Id,
            propertyNumber: asset.PropertyNumber,
            description: asset.Description,
            acquisitionCost: asset.AcquisitionCost,
            tenantId: tenantId));

        return asset;
    }

    /// <summary>
    /// Records when an asset is issued to a custodian.
    /// </summary>
    public void IssueToEmployee(Guid employeeId, string issuedBy, string? remarks = null)
    {
        if (Status == AssetStatus.Issued)
            return;

        var previousCustodianId = CurrentCustodianId;
        Status = AssetStatus.Issued;
        CurrentCustodianId = employeeId;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = issuedBy;

        AddDomainEvent(AssetIssuedEvent.Create(
            assetId: Id,
            employeeId: employeeId,
            previousCustodianId: previousCustodianId,
            issuedBy: issuedBy,
            remarks: remarks,
            tenantId: TenantId));
    }

    /// <summary>
    /// Records when an asset is returned.
    /// </summary>
    public void Return(Guid? toLocationId, string returnedBy, string? remarks = null)
    {
        if (Status != AssetStatus.Issued)
            return;

        var previousCustodianId = CurrentCustodianId;
        Status = AssetStatus.Active;
        CurrentCustodianId = null;
        CurrentLocationId = toLocationId;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = returnedBy;

        AddDomainEvent(AssetReturnedEvent.Create(
            assetId: Id,
            previousCustodianId: previousCustodianId,
            toLocationId: toLocationId,
            returnedBy: returnedBy,
            remarks: remarks,
            tenantId: TenantId));
    }

    /// <summary>
    /// Records when an asset is transferred to a new location.
    /// </summary>
    public void TransferToLocation(Guid toLocationId, string transferredBy, string? remarks = null)
    {
        var previousLocationId = CurrentLocationId;
        CurrentLocationId = toLocationId;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = transferredBy;

        AddDomainEvent(AssetTransferredEvent.Create(
            assetId: Id,
            fromLocationId: previousLocationId,
            toLocationId: toLocationId,
            transferredBy: transferredBy,
            remarks: remarks,
            tenantId: TenantId));
    }

    /// <summary>
    /// Records when an asset is disposed.
    /// </summary>
    public void Dispose(string disposedBy, string? remarks = null)
    {
        if (Status == AssetStatus.Disposed)
            return;

        Status = AssetStatus.Disposed;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = disposedBy;

        AddDomainEvent(AssetDisposedEvent.Create(
            assetId: Id,
            disposedBy: disposedBy,
            remarks: remarks,
            tenantId: TenantId));
    }

    /// <summary>
    /// Records when an asset is sold.
    /// </summary>
    public void Sale(string soldBy, string? remarks = null)
    {
        if (Status == AssetStatus.Sold)
            return;

        Status = AssetStatus.Sold;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = soldBy;

        AddDomainEvent(AssetSoldEvent.Create(
            assetId: Id,
            soldBy: soldBy,
            remarks: remarks,
            tenantId: TenantId));
    }

    /// <summary>
    /// Updates asset condition.
    /// </summary>
    public void UpdateCondition(AssetCondition newCondition, string updatedBy)
    {
        if (Condition == newCondition)
            return;

        var previousCondition = Condition;
        Condition = newCondition;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = updatedBy;

        AddDomainEvent(AssetConditionChangedEvent.Create(
            assetId: Id,
            previousCondition: previousCondition,
            newCondition: newCondition,
            updatedBy: updatedBy,
            tenantId: TenantId));
    }

    /// <summary>
    /// Updates core asset information.
    /// </summary>
    public void Update(
        string propertyNumber,
        string description,
        string category,
        DateOnly acquisitionDate,
        decimal acquisitionCost,
        int usefulLifeDays,
        decimal residualValue,
        AssetCondition condition,
        AssetStatus status,
        Guid? currentCustodianId,
        Guid? currentLocationId,
        Guid? supplierId,
        string updatedBy)
    {
        PropertyNumber = propertyNumber;
        Description = description;
        Category = category;
        AcquisitionDate = acquisitionDate;
        AcquisitionCost = acquisitionCost;
        UsefulLifeDays = usefulLifeDays;
        ResidualValue = residualValue;
        Condition = condition;
        Status = status;
        CurrentCustodianId = currentCustodianId;
        CurrentLocationId = currentLocationId;
        SupplierId = supplierId;
        LastModifiedOnUtc = DateTimeOffset.UtcNow;
        LastModifiedBy = updatedBy;
    }
}
