namespace FSH.Modules.Library.Persistence.Configurations;

/// <summary>
/// Entity Framework Core configuration for Supplier entity.
/// </summary>
public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("suppliers", "library");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.Address)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(s => s.TIN)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(s => new { s.TenantId, s.TIN })
            .IsUnique()
            .HasDatabaseName("ix_suppliers_tenant_tin");

        builder.Property(s => s.ContactPerson)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.TenantId)
            .IsRequired();
    }
}
