using FSH.Modules.AssetInventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.AssetInventory.Persistence.Configurations;

/// <summary>
/// Entity configuration for PPEIR and PPEIRItem.
/// </summary>
public class PPEIRConfiguration : IEntityTypeConfiguration<PPEIR>
{
    public void Configure(EntityTypeBuilder<PPEIR> builder)
    {
        builder.ToTable("ppeirs", "assetinventory");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.ReferenceNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.TransactionType)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(p => p.TransactionDate)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(500);

        builder.Property(p => p.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(p => p.CreatedBy)
            .HasMaxLength(256);

        builder.Property(p => p.LastModifiedBy)
            .HasMaxLength(256);

        builder.Property(p => p.DeletedBy)
            .HasMaxLength(256);

        // Relationships
        builder.HasMany(p => p.Items)
            .WithOne(i => i.PPEIR)
            .HasForeignKey(i => i.PPEIRId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(p => new { p.ReferenceNumber, p.TenantId })
            .IsUnique();

        builder.HasIndex(p => p.TenantId);

        builder.HasIndex(p => p.IsDeleted);
    }
}

/// <summary>
/// Entity configuration for PPEIRItem.
/// </summary>
public class PPEIRItemConfiguration : IEntityTypeConfiguration<PPEIRItem>
{
    public void Configure(EntityTypeBuilder<PPEIRItem> builder)
    {
        builder.ToTable("ppeir_items", "assetinventory");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.PPEIRId)
            .IsRequired();

        builder.Property(i => i.AssetId)
            .IsRequired();

        // Relationships
        builder.HasOne(i => i.Asset)
            .WithMany()
            .HasForeignKey(i => i.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(i => i.PPEIRId);

        builder.HasIndex(i => i.AssetId);
    }
}
