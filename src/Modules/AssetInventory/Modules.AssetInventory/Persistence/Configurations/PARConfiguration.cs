using FSH.Modules.AssetInventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.AssetInventory.Persistence.Configurations;

/// <summary>
/// Entity configuration for PAR and PARItem.
/// </summary>
public class PARConfiguration : IEntityTypeConfiguration<PAR>
{
    public void Configure(EntityTypeBuilder<PAR> builder)
    {
        builder.ToTable("pars", "assetinventory");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.ReceiptNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.ReceiptDate)
            .IsRequired();

        builder.Property(p => p.EmployeeId)
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
            .WithOne(i => i.PAR)
            .HasForeignKey(i => i.PARId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(p => new { p.ReceiptNumber, p.TenantId })
            .IsUnique();

        builder.HasIndex(p => p.TenantId);

        builder.HasIndex(p => p.IsDeleted);
    }
}

/// <summary>
/// Entity configuration for PARItem.
/// </summary>
public class PARItemConfiguration : IEntityTypeConfiguration<PARItem>
{
    public void Configure(EntityTypeBuilder<PARItem> builder)
    {
        builder.ToTable("par_items", "assetinventory");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.PARId)
            .IsRequired();

        builder.Property(i => i.AssetId)
            .IsRequired();

        // Relationships
        builder.HasOne(i => i.Asset)
            .WithMany()
            .HasForeignKey(i => i.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(i => i.PARId);

        builder.HasIndex(i => i.AssetId);
    }
}
