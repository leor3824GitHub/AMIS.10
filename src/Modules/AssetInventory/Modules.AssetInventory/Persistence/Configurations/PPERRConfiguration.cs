using FSH.Modules.AssetInventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.AssetInventory.Persistence.Configurations;

/// <summary>
/// Entity configuration for PPERR and PPERRItem.
/// </summary>
public class PPERRConfiguration : IEntityTypeConfiguration<PPERR>
{
    public void Configure(EntityTypeBuilder<PPERR> builder)
    {
        builder.ToTable("pperrs", "assetinventory");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.ReceiptNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.ReceiptDate)
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
            .WithOne(i => i.PPERR)
            .HasForeignKey(i => i.PPERRId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(p => new { p.ReceiptNumber, p.TenantId })
            .IsUnique();

        builder.HasIndex(p => p.TenantId);

        builder.HasIndex(p => p.IsDeleted);
    }
}

/// <summary>
/// Entity configuration for PPERRItem.
/// </summary>
public class PPERRItemConfiguration : IEntityTypeConfiguration<PPERRItem>
{
    public void Configure(EntityTypeBuilder<PPERRItem> builder)
    {
        builder.ToTable("pperr_items", "assetinventory");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.PPERRId)
            .IsRequired();

        builder.Property(i => i.AssetId)
            .IsRequired();

        builder.Property(i => i.Quantity)
            .IsRequired();

        // Relationships
        builder.HasOne(i => i.Asset)
            .WithMany()
            .HasForeignKey(i => i.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(i => i.PPERRId);

        builder.HasIndex(i => i.AssetId);
    }
}
