namespace FSH.Modules.SemiExpendableAssets.Contracts.DTOs;

/// <summary>DTO for Receipt (RIS/DR/Purchase document).</summary>
public sealed class ReceiptDto
{
    public Guid Id { get; set; }
    public string ReceiptNumber { get; set; } = null!;
    public string ReceiptType { get; set; } = null!;
    public DateTimeOffset ReceiptDate { get; set; }
    public Guid? SupplierId { get; set; }
    public string? DeliveryReferenceNo { get; set; }
    public string? Remarks { get; set; }
    public List<ReceiptItemDto> Items { get; set; } = [];
}

/// <summary>DTO for creating a Receipt.</summary>
public sealed class CreateReceiptDto
{
    public string ReceiptNumber { get; set; } = null!;
    public string ReceiptType { get; set; } = null!;
    public DateTimeOffset ReceiptDate { get; set; }
    public Guid? SupplierId { get; set; }
    public string? DeliveryReferenceNo { get; set; }
    public string? Remarks { get; set; }
    public List<CreateReceiptItemDto> Items { get; set; } = [];
}

/// <summary>DTO for a Receipt line item.</summary>
public sealed class ReceiptItemDto
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public string Condition { get; set; } = null!;
}

/// <summary>DTO for creating a Receipt line item.</summary>
public sealed class CreateReceiptItemDto
{
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public string Condition { get; set; } = "New";
}

/// <summary>DTO for Inventory Custodian Slip (ICS).</summary>
public sealed class InventoryCustodianSlipDto
{
    public Guid Id { get; set; }
    public string ICSNumber { get; set; } = null!;
    public DateTimeOffset ICSDate { get; set; }
    public Guid CustodianId { get; set; }
    public Guid LocationId { get; set; }
    public string? Purpose { get; set; }
    public string? Remarks { get; set; }
    public List<ICSItemDto> Items { get; set; } = [];
}

/// <summary>DTO for creating an ICS.</summary>
public sealed class CreateInventoryCustodianSlipDto
{
    public string ICSNumber { get; set; } = null!;
    public DateTimeOffset ICSDate { get; set; }
    public Guid CustodianId { get; set; }
    public Guid LocationId { get; set; }
    public string? Purpose { get; set; }
    public string? Remarks { get; set; }
    public List<Guid> AssetIds { get; set; } = [];
}

/// <summary>DTO for an ICS line item.</summary>
public sealed class ICSItemDto
{
    public Guid Id { get; set; }
    public Guid AssetId { get; set; }
    public string? Remarks { get; set; }
}

/// <summary>DTO for Return Document.</summary>
public sealed class ReturnDocumentDto
{
    public Guid Id { get; set; }
    public string ReturnDocumentNumber { get; set; } = null!;
    public DateTimeOffset ReturnDate { get; set; }
    public Guid FromCustodianId { get; set; }
    public Guid ToLocationId { get; set; }
    public string? Reason { get; set; }
    public string? Remarks { get; set; }
    public List<ReturnItemDto> Items { get; set; } = [];
}

/// <summary>DTO for creating a Return Document.</summary>
public sealed class CreateReturnDocumentDto
{
    public string ReturnDocumentNumber { get; set; } = null!;
    public DateTimeOffset ReturnDate { get; set; }
    public Guid FromCustodianId { get; set; }
    public Guid ToLocationId { get; set; }
    public string? Reason { get; set; }
    public string? Remarks { get; set; }
    public List<Guid> AssetIds { get; set; } = [];
}

/// <summary>DTO for a Return Document line item.</summary>
public sealed class ReturnItemDto
{
    public Guid Id { get; set; }
    public Guid AssetId { get; set; }
    public string? Remarks { get; set; }
}

/// <summary>DTO for Transfer Document.</summary>
public sealed class TransferDocumentDto
{
    public Guid Id { get; set; }
    public string TransferDocumentNumber { get; set; } = null!;
    public DateTimeOffset TransferDate { get; set; }
    public Guid FromCustodianId { get; set; }
    public Guid? ToCustodianId { get; set; }
    public Guid? ToLocationId { get; set; }
    public string TransferType { get; set; } = null!;
    public string? Reason { get; set; }
    public string? Remarks { get; set; }
    public List<TransferItemDto> Items { get; set; } = [];
}

/// <summary>DTO for creating a Transfer Document.</summary>
public sealed class CreateTransferDocumentDto
{
    public string TransferDocumentNumber { get; set; } = null!;
    public DateTimeOffset TransferDate { get; set; }
    public Guid FromCustodianId { get; set; }
    public Guid? ToCustodianId { get; set; }
    public Guid? ToLocationId { get; set; }
    public string TransferType { get; set; } = null!;
    public string? Reason { get; set; }
    public string? Remarks { get; set; }
    public List<Guid> AssetIds { get; set; } = [];
}

/// <summary>DTO for a Transfer Document line item.</summary>
public sealed class TransferItemDto
{
    public Guid Id { get; set; }
    public Guid AssetId { get; set; }
    public string? Remarks { get; set; }
}
