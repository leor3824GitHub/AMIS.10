namespace FSH.Modules.Library.Persistence.Configurations;

/// <summary>
/// Entity Framework Core configuration for Office entity.
/// </summary>
public class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.ToTable("offices", "library");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(o => o.Location)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(o => o.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(o => new { o.TenantId, o.Code })
            .IsUnique()
            .HasDatabaseName("ix_offices_tenant_code");

        builder.Property(o => o.TenantId)
            .IsRequired();
    }
}
