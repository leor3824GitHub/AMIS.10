using FSH.Modules.AssetInventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.AssetInventory.Persistence.Configurations;

/// <summary>
/// Entity configuration for RRP and RRPItem.
/// </summary>
public class RRPConfiguration : IEntityTypeConfiguration<RRP>
{
    public void Configure(EntityTypeBuilder<RRP> builder)
    {
        builder.ToTable("rrps", "assetinventory");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.ReceiptNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(r => r.ReceiptDate)
            .IsRequired();

        builder.Property(r => r.EmployeeId)
            .IsRequired();

        builder.Property(r => r.Description)
            .HasMaxLength(500);

        builder.Property(r => r.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(r => r.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(r => r.CreatedBy)
            .HasMaxLength(256);

        builder.Property(r => r.LastModifiedBy)
            .HasMaxLength(256);

        builder.Property(r => r.DeletedBy)
            .HasMaxLength(256);

        // Relationships
        builder.HasMany(r => r.Items)
            .WithOne(i => i.RRP)
            .HasForeignKey(i => i.RRPId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(r => new { r.ReceiptNumber, r.TenantId })
            .IsUnique();

        builder.HasIndex(r => r.TenantId);

        builder.HasIndex(r => r.IsDeleted);
    }
}

/// <summary>
/// Entity configuration for RRPItem.
/// </summary>
public class RRPItemConfiguration : IEntityTypeConfiguration<RRPItem>
{
    public void Configure(EntityTypeBuilder<RRPItem> builder)
    {
        builder.ToTable("rrp_items", "assetinventory");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.RRPId)
            .IsRequired();

        builder.Property(i => i.AssetId)
            .IsRequired();

        // Relationships
        builder.HasOne(i => i.Asset)
            .WithMany()
            .HasForeignKey(i => i.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(i => i.RRPId);

        builder.HasIndex(i => i.AssetId);
    }
}
