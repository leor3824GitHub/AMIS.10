using FSH.Modules.SemiExpendableAssets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.SemiExpendableAssets.Persistence.Configurations;

public sealed class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    {
        builder.ToTable("receipts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ReceiptNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ReceiptType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ReceiptDate)
            .IsRequired();

        builder.Property(x => x.DeliveryReferenceNo)
            .HasMaxLength(100);

        builder.Property(x => x.Remarks)
            .HasMaxLength(1000);

        builder.Property(x => x.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        // Relationships
        builder.HasMany<ReceiptItem>()
            .WithOne()
            .HasForeignKey(ri => ri.ReceiptId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.ReceiptNumber)
            .IsUnique();
        builder.HasIndex(x => x.TenantId);

        // Soft delete filter
        builder.HasQueryFilter(x => x.DeletedOnUtc == null);
    }
}

public sealed class ReceiptItemConfiguration : IEntityTypeConfiguration<ReceiptItem>
{
    public void Configure(EntityTypeBuilder<ReceiptItem> builder)
    {
        builder.ToTable("receipt_items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.UnitCost)
            .HasPrecision(18, 2);

        builder.Property(x => x.Condition)
            .IsRequired();

        // Indexes
        builder.HasIndex(x => x.ReceiptId);
    }
}
