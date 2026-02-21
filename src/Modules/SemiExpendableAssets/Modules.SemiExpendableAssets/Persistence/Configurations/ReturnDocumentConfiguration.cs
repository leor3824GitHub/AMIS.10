using FSH.Modules.SemiExpendableAssets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.SemiExpendableAssets.Persistence.Configurations;

public sealed class ReturnDocumentConfiguration : IEntityTypeConfiguration<ReturnDocument>
{
    public void Configure(EntityTypeBuilder<ReturnDocument> builder)
    {
        builder.ToTable("return_documents");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ReturnDocumentNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ReturnDate)
            .IsRequired();

        builder.Property(x => x.FromCustodianId)
            .IsRequired();

        builder.Property(x => x.ToLocationId)
            .IsRequired();

        builder.Property(x => x.Reason)
            .HasMaxLength(500);

        builder.Property(x => x.Remarks)
            .HasMaxLength(1000);

        builder.Property(x => x.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        // Relationships
        builder.HasMany<ReturnItem>()
            .WithOne()
            .HasForeignKey(ri => ri.ReturnDocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.ReturnDocumentNumber)
            .IsUnique();
        builder.HasIndex(x => x.TenantId);

        // Soft delete filter
        builder.HasQueryFilter(x => x.DeletedOnUtc == null);
    }
}

public sealed class ReturnItemConfiguration : IEntityTypeConfiguration<ReturnItem>
{
    public void Configure(EntityTypeBuilder<ReturnItem> builder)
    {
        builder.ToTable("return_items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AssetId)
            .IsRequired();

        builder.Property(x => x.Remarks)
            .HasMaxLength(500);

        // Indexes
        builder.HasIndex(x => x.ReturnDocumentId);
        builder.HasIndex(x => x.AssetId);
    }
}
