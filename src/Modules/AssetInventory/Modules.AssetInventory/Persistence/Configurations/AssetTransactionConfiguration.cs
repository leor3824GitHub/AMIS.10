using FSH.Modules.AssetInventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.AssetInventory.Persistence.Configurations;

/// <summary>
/// Entity configuration for AssetTransaction.
/// </summary>
public class AssetTransactionConfiguration : IEntityTypeConfiguration<AssetTransaction>
{
    public void Configure(EntityTypeBuilder<AssetTransaction> builder)
    {
        builder.ToTable("asset_transactions", "assetinventory");

        builder.HasKey(t => t.Id);

        // Properties
        builder.Property(t => t.AssetId)
            .IsRequired();

        builder.Property(t => t.TransactionType)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(t => t.ReferenceNo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Description)
            .HasMaxLength(500);

        builder.Property(t => t.TransactionDate)
            .IsRequired();

        builder.Property(t => t.Remarks)
            .HasMaxLength(1000);

        builder.Property(t => t.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(t => t.CreatedBy)
            .HasMaxLength(256);

        builder.Property(t => t.LastModifiedBy)
            .HasMaxLength(256);

        builder.Property(t => t.DeletedBy)
            .HasMaxLength(256);

        // Relationships
        builder.HasOne(t => t.Asset)
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(t => t.AssetId);

        builder.HasIndex(t => t.TenantId);

        builder.HasIndex(t => t.TransactionDate);

        builder.HasIndex(t => t.IsDeleted);
    }
}
