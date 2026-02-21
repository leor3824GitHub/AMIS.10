using FSH.Modules.SemiExpendableAssets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.SemiExpendableAssets.Persistence.Configurations;

public sealed class SemiExpendableAssetConfiguration : IEntityTypeConfiguration<SemiExpendableAsset>
{
    public void Configure(EntityTypeBuilder<SemiExpendableAsset> builder)
    {
        builder.ToTable("semi_expendable_assets");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ICSNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.AcquisitionDate)
            .IsRequired();

        builder.Property(x => x.AcquisitionCost)
            .HasPrecision(18, 2);

        builder.Property(x => x.Condition)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        // Indexes
        builder.HasIndex(x => x.ICSNumber)
            .IsUnique();

        // Composite index for tenant filtering + ordering by creation date
        builder.HasIndex(x => new { x.TenantId, x.CreatedOnUtc })
            .IsDescending(false, true)  // TenantId ASC, CreatedOnUtc DESC
            .HasDatabaseName("ix_semiexpendableassets_tenant_created");

        // Composite indexes for common queries
        builder.HasIndex(x => new { x.TenantId, x.Status })
            .HasDatabaseName("ix_semiexpendableassets_tenant_status");

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.Condition);

        // Foreign key lookups for asset assignments
        builder.HasIndex(x => x.CurrentCustodianId)
            .HasDatabaseName("ix_semiexpendableassets_custodian");

        builder.HasIndex(x => x.CurrentLocationId)
            .HasDatabaseName("ix_semiexpendableassets_location");

        // Soft delete filtering optimization
        builder.HasIndex(x => new { x.TenantId, x.DeletedOnUtc })
            .HasDatabaseName("ix_semiexpendableassets_tenant_deleted");
    }
}
