using FSH.Framework.Core.Domain;

namespace FSH.Modules.SemiExpendableAssets.Domain.Events;

/// <summary>Raised when a new semi-expendable asset is created.</summary>
public sealed record SemiExpendableAssetCreatedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    string ICSNumber,
    string Description,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static SemiExpendableAssetCreatedEvent Create(Guid assetId, string icsNumber, string description, string? tenantId = null)
        => new(Guid.NewGuid(), DateTimeOffset.UtcNow, assetId, icsNumber, description, null, tenantId);
}

/// <summary>Raised when an asset is issued to a custodian.</summary>
public sealed record AssetIssuedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    string ICSNumber,
    Guid CustodianId,
    Guid LocationId,
    string? Remarks = null,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetIssuedEvent Create(Guid assetId, string icsNumber, Guid custodianId, Guid locationId, string? remarks = null, string? tenantId = null)
        => new(Guid.NewGuid(), DateTimeOffset.UtcNow, assetId, icsNumber, custodianId, locationId, remarks, null, tenantId);
}

/// <summary>Raised when an asset is returned from a custodian.</summary>
public sealed record AssetReturnedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    string ICSNumber,
    Guid FromCustodianId,
    Guid ToLocationId,
    string? Remarks = null,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetReturnedEvent Create(Guid assetId, string icsNumber, Guid fromCustodianId, Guid toLocationId, string? remarks = null, string? tenantId = null)
        => new(Guid.NewGuid(), DateTimeOffset.UtcNow, assetId, icsNumber, fromCustodianId, toLocationId, remarks, null, tenantId);
}

/// <summary>Raised when an asset is transferred to another custodian.</summary>
public sealed record AssetTransferredEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    string ICSNumber,
    Guid FromCustodianId,
    Guid ToCustodianId,
    Guid ToLocationId,
    string? Remarks = null,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetTransferredEvent Create(Guid assetId, string icsNumber, Guid fromCustodianId, Guid toCustodianId, Guid toLocationId, string? remarks = null, string? tenantId = null)
        => new(Guid.NewGuid(), DateTimeOffset.UtcNow, assetId, icsNumber, fromCustodianId, toCustodianId, toLocationId, remarks, null, tenantId);
}

/// <summary>Raised when an asset is disposed.</summary>
public sealed record AssetDisposedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    string ICSNumber,
    string? Remarks = null,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetDisposedEvent Create(Guid assetId, string icsNumber, string? remarks = null, string? tenantId = null)
        => new(Guid.NewGuid(), DateTimeOffset.UtcNow, assetId, icsNumber, remarks, null, tenantId);
}

/// <summary>Raised when asset details are updated.</summary>
public sealed record AssetDetailsUpdatedEvent(
    Guid EventId,
    DateTimeOffset OccurredOnUtc,
    Guid AssetId,
    string ICSNumber,
    string? CorrelationId = null,
    string? TenantId = null
) : DomainEvent(EventId, OccurredOnUtc, CorrelationId, TenantId)
{
    public static AssetDetailsUpdatedEvent Create(Guid assetId, string icsNumber, string? tenantId = null)
        => new(Guid.NewGuid(), DateTimeOffset.UtcNow, assetId, icsNumber, null, tenantId);
}
