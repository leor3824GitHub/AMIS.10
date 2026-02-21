namespace FSH.Modules.AssetInventory.Domain;

/// <summary>
/// Condition status of a physical asset.
/// </summary>
public enum AssetCondition
{
    New = 0,
    Good = 1,
    Fair = 2,
    Poor = 3
}

/// <summary>
/// Operational status of a physical asset.
/// </summary>
public enum AssetStatus
{
    Active = 0,
    Issued = 1,
    Disposed = 2,
    Sold = 3
}

/// <summary>
/// Type of transaction recorded for asset movements.
/// </summary>
public enum TransactionType
{
    Receipt = 0,
    Issue = 1,
    Return = 2,
    Transfer = 3,
    Sale = 4,
    Disposal = 5
}
