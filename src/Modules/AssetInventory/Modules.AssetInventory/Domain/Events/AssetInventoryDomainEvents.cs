using FSH.Framework.Core.Domain;

namespace FSH.Modules.AssetInventory.Domain.Events;

#region Physical Asset Events

/// <summary>Event raised when a physical asset is created.</summary>
public sealed record PhysicalAssetCreatedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    string PropertyNumber,
    string Description,
    decimal AcquisitionCost,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static PhysicalAssetCreatedEvent Create(
        Guid assetId,
        string propertyNumber,
        string description,
        decimal acquisitionCost,
        string? tenantId = null)
    {
        return new PhysicalAssetCreatedEvent(
            EventId: Guid.NewGuid(),
            OccurredOnUtc: DateTimeOffset.UtcNow,
            AssetId: assetId,
            PropertyNumber: propertyNumber,
            Description: description,
            AcquisitionCost: acquisitionCost,
            TenantId: tenantId
        );
    }
}

/// <summary>Event raised when an asset is issued to an employee.</summary>
public sealed record AssetIssuedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    Guid EmployeeId,
    Guid? PreviousCustodianId,
    string IssuedBy,
    string? Remarks,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetIssuedEvent Create(
        Guid assetId,
        Guid employeeId,
        Guid? previousCustodianId,
        string issuedBy,
        string? remarks = null,
        string? tenantId = null)
    {
        return new AssetIssuedEvent(
            EventId: Guid.NewGuid(),
            OccurredOnUtc: DateTimeOffset.UtcNow,
            AssetId: assetId,
            EmployeeId: employeeId,
            PreviousCustodianId: previousCustodianId,
            IssuedBy: issuedBy,
            Remarks: remarks,
            TenantId: tenantId
        );
    }
}

/// <summary>Event raised when an asset is returned.</summary>
public sealed record AssetReturnedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    Guid? PreviousCustodianId,
    Guid? ToLocationId,
    string ReturnedBy,
    string? Remarks,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetReturnedEvent Create(
        Guid assetId,
        Guid? previousCustodianId,
        Guid? toLocationId,
        string returnedBy,
        string? remarks = null,
        string? tenantId = null)
    {
        return new AssetReturnedEvent(
            EventId: Guid.NewGuid(),
            OccurredOnUtc: DateTimeOffset.UtcNow,
            AssetId: assetId,
            PreviousCustodianId: previousCustodianId,
            ToLocationId: toLocationId,
            ReturnedBy: returnedBy,
            Remarks: remarks,
            TenantId: tenantId
        );
    }
}

/// <summary>Event raised when an asset is transferred to a new location.</summary>
public sealed record AssetTransferredEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    Guid? FromLocationId,
    Guid? ToLocationId,
    string TransferredBy,
    string? Remarks,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetTransferredEvent Create(
        Guid assetId,
        Guid? fromLocationId,
        Guid? toLocationId,
        string transferredBy,
        string? remarks = null,
        string? tenantId = null)
    {
        return new AssetTransferredEvent(
            EventId: Guid.NewGuid(),
            OccurredOnUtc: DateTimeOffset.UtcNow,
            AssetId: assetId,
            FromLocationId: fromLocationId,
            ToLocationId: toLocationId,
            TransferredBy: transferredBy,
            Remarks: remarks,
            TenantId: tenantId
        );
    }
}

/// <summary>Event raised when an asset is disposed.</summary>
public sealed record AssetDisposedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    string DisposedBy,
    string? Remarks,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetDisposedEvent Create(
        Guid assetId,
        string disposedBy,
        string? remarks = null,
        string? tenantId = null)
    {
        return new AssetDisposedEvent(
            EventId: Guid.NewGuid(),
            OccurredOnUtc: DateTimeOffset.UtcNow,
            AssetId: assetId,
            DisposedBy: disposedBy,
            Remarks: remarks,
            TenantId: tenantId
        );
    }
}

/// <summary>Event raised when an asset is sold.</summary>
public sealed record AssetSoldEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    string SoldBy,
    string? Remarks,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetSoldEvent Create(
        Guid assetId,
        string soldBy,
        string? remarks = null,
        string? tenantId = null)
    {
        return new AssetSoldEvent(
            EventId: Guid.NewGuid(),
            OccurredOnUtc: DateTimeOffset.UtcNow,
            AssetId: assetId,
            SoldBy: soldBy,
            Remarks: remarks,
            TenantId: tenantId
        );
    }
}

/// <summary>Event raised when an asset's condition changes.</summary>
public sealed record AssetConditionChangedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    AssetCondition PreviousCondition,
    AssetCondition NewCondition,
    string UpdatedBy,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetConditionChangedEvent Create(
        Guid assetId,
        AssetCondition previousCondition,
        AssetCondition newCondition,
        string updatedBy,
        string? tenantId = null)
    {
        return new AssetConditionChangedEvent(
            EventId: Guid.NewGuid(),
            OccurredOnUtc: DateTimeOffset.UtcNow,
            AssetId: assetId,
            PreviousCondition: previousCondition,
            NewCondition: newCondition,
            UpdatedBy: updatedBy,
            TenantId: tenantId
        );
    }
}

#endregion
