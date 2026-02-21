namespace FSH.Modules.SemiExpendableAssets.Contracts.DTOs;

/// <summary>DTO for Employee.</summary>
public sealed class EmployeeDto
{
    public Guid Id { get; set; }
    public string EmployeeCode { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Position { get; set; } = null!;
    public Guid OfficeId { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
}

/// <summary>DTO for creating an Employee.</summary>
public sealed class CreateEmployeeDto
{
    public string EmployeeCode { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Position { get; set; } = null!;
    public Guid OfficeId { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
}

/// <summary>DTO for Office/Location.</summary>
public sealed class OfficeDto
{
    public Guid Id { get; set; }
    public string OfficeName { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string? Address { get; set; }
    public string? ContactNumber { get; set; }
}

/// <summary>DTO for creating an Office.</summary>
public sealed class CreateOfficeDto
{
    public string OfficeName { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string? Address { get; set; }
    public string? ContactNumber { get; set; }
}

/// <summary>DTO for Supplier.</summary>
public sealed class SupplierDto
{
    public Guid Id { get; set; }
    public string SupplierCode { get; set; } = null!;
    public string SupplierName { get; set; } = null!;
    public string? Address { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
    public string? TIN { get; set; }
}

/// <summary>DTO for creating a Supplier.</summary>
public sealed class CreateSupplierDto
{
    public string SupplierCode { get; set; } = null!;
    public string SupplierName { get; set; } = null!;
    public string? Address { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
    public string? TIN { get; set; }
}
