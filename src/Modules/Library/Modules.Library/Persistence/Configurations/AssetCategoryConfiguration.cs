namespace FSH.Modules.Library.Persistence.Configurations;

/// <summary>
/// Entity Framework Core configuration for AssetCategory entity.
/// </summary>
public class AssetCategoryConfiguration : IEntityTypeConfiguration<AssetCategory>
{
    public void Configure(EntityTypeBuilder<AssetCategory> builder)
    {
        builder.ToTable("asset_categories", "library");

        builder.HasKey(ac => ac.Id);

        builder.Property(ac => ac.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(ac => ac.Description)
            .HasMaxLength(500);

        builder.Property(ac => ac.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(ac => new { ac.TenantId, ac.Code })
            .IsUnique()
            .HasDatabaseName("ix_asset_categories_tenant_code");

        builder.Property(ac => ac.TenantId)
            .IsRequired();
    }
}
