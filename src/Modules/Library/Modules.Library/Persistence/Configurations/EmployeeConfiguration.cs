namespace FSH.Modules.Library.Persistence.Configurations;

/// <summary>
/// Entity Framework Core configuration for Employee entity.
/// </summary>
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employees", "library");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(e => new { e.TenantId, e.Email })
            .IsUnique()
            .HasDatabaseName("ix_employees_tenant_email");

        builder.Property(e => e.Position)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.OfficeId)
            .IsRequired(false);

        builder.Property(e => e.TenantId)
            .IsRequired();

        // Foreign key lookup for office assignments
        builder.HasIndex(e => e.OfficeId)
            .HasDatabaseName("ix_employees_office");

        // Composite index for common queries
        builder.HasIndex(e => new { e.TenantId, e.OfficeId })
            .HasDatabaseName("ix_employees_tenant_office");
    }
}
