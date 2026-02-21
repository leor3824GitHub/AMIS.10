namespace FSH.Modules.SemiExpendableAssets.Domain;

/// <summary>Condition status of a semi-expendable asset.</summary>
public enum AssetCondition
{
    New = 0,
    Good = 1,
    Fair = 2,
    Poor = 3
}

/// <summary>Operational status of a semi-expendable asset.</summary>
public enum AssetStatus
{
    Active = 0,
    Issued = 1,
    Returned = 2,
    Disposed = 3
}

/// <summary>Type of asset transaction in the history.</summary>
public enum AssetTransactionType
{
    Receipt = 0,
    Issue = 1,
    Return = 2,
    Transfer = 3,
    Disposal = 4
}
