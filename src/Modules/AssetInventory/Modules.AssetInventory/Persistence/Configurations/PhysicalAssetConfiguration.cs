using FSH.Modules.AssetInventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.AssetInventory.Persistence.Configurations;

/// <summary>
/// Entity configuration for PhysicalAsset.
/// </summary>
public class PhysicalAssetConfiguration : IEntityTypeConfiguration<PhysicalAsset>
{
    public void Configure(EntityTypeBuilder<PhysicalAsset> builder)
    {
        builder.ToTable("physical_assets", "assetinventory");

        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.PropertyNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.AcquisitionDate)
            .IsRequired();

        builder.Property(p => p.AcquisitionCost)
            .HasPrecision(18, 2);

        builder.Property(p => p.UsefulLifeDays)
            .IsRequired();

        builder.Property(p => p.ResidualValue)
            .HasPrecision(18, 2);

        builder.Property(p => p.Condition)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(p => p.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(p => p.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(p => p.CreatedBy)
            .HasMaxLength(256);

        builder.Property(p => p.LastModifiedBy)
            .HasMaxLength(256);

        builder.Property(p => p.DeletedBy)
            .HasMaxLength(256);

        // Indexes
        builder.HasIndex(p => new { p.PropertyNumber, p.TenantId })
            .IsUnique();

        // Composite index for tenant filtering + ordering by creation date
        builder.HasIndex(p => new { p.TenantId, p.CreatedOnUtc })
            .IsDescending(false, true)  // TenantId ASC, CreatedOnUtc DESC
            .HasDatabaseName("ix_physicalassets_tenant_created");

        // Composite indexes for common WHERE/ORDER patterns (TenantId filters most queries)
        builder.HasIndex(p => new { p.TenantId, p.Status })
            .HasDatabaseName("ix_physicalassets_tenant_status");

        builder.HasIndex(p => new { p.TenantId, p.IsDeleted })
            .HasDatabaseName("ix_physicalassets_tenant_isdeleted");

        // Foreign key lookups
        builder.HasIndex(p => p.CurrentCustodianId)
            .HasDatabaseName("ix_physicalassets_custodian");

        builder.HasIndex(p => p.CurrentLocationId)
            .HasDatabaseName("ix_physicalassets_location");

        builder.HasIndex(p => p.SupplierId)
            .HasDatabaseName("ix_physicalassets_supplier");

        builder.HasIndex(p => p.IsDeleted);
    }
}
