using FSH.Modules.SemiExpendableAssets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.SemiExpendableAssets.Persistence.Configurations;

public sealed class AssetTransactionConfiguration : IEntityTypeConfiguration<AssetTransaction>
{
    public void Configure(EntityTypeBuilder<AssetTransaction> builder)
    {
        builder.ToTable("asset_transactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AssetId)
            .IsRequired();

        builder.Property(x => x.TransactionType)
            .IsRequired();

        builder.Property(x => x.ReferenceNo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.TransactionDate)
            .IsRequired();

        builder.Property(x => x.Remarks)
            .HasMaxLength(1000);

        builder.Property(x => x.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        // Indexes
        builder.HasIndex(x => x.AssetId);
        builder.HasIndex(x => x.TenantId);
        builder.HasIndex(x => x.TransactionDate);

        // Soft delete filter
        builder.HasQueryFilter(x => x.DeletedOnUtc == null);
    }
}
