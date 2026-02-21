using FSH.Modules.SemiExpendableAssets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.SemiExpendableAssets.Persistence.Configurations;

public sealed class TransferDocumentConfiguration : IEntityTypeConfiguration<TransferDocument>
{
    public void Configure(EntityTypeBuilder<TransferDocument> builder)
    {
        builder.ToTable("transfer_documents");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TransferDocumentNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.TransferDate)
            .IsRequired();

        builder.Property(x => x.FromCustodianId)
            .IsRequired();

        builder.Property(x => x.TransferType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Reason)
            .HasMaxLength(500);

        builder.Property(x => x.Remarks)
            .HasMaxLength(1000);

        builder.Property(x => x.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        // Relationships
        builder.HasMany<TransferItem>()
            .WithOne()
            .HasForeignKey(ti => ti.TransferDocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.TransferDocumentNumber)
            .IsUnique();
        builder.HasIndex(x => x.TenantId);

        // Soft delete filter
        builder.HasQueryFilter(x => x.DeletedOnUtc == null);
    }
}

public sealed class TransferItemConfiguration : IEntityTypeConfiguration<TransferItem>
{
    public void Configure(EntityTypeBuilder<TransferItem> builder)
    {
        builder.ToTable("transfer_items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AssetId)
            .IsRequired();

        builder.Property(x => x.Remarks)
            .HasMaxLength(500);

        // Indexes
        builder.HasIndex(x => x.TransferDocumentId);
        builder.HasIndex(x => x.AssetId);
    }
}
