using FSH.Modules.SemiExpendableAssets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Modules.SemiExpendableAssets.Persistence.Configurations;

public sealed class InventoryCustodianSlipConfiguration : IEntityTypeConfiguration<InventoryCustodianSlip>
{
    public void Configure(EntityTypeBuilder<InventoryCustodianSlip> builder)
    {
        builder.ToTable("inventory_custodian_slips");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ICSNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ICSDate)
            .IsRequired();

        builder.Property(x => x.CustodianId)
            .IsRequired();

        builder.Property(x => x.LocationId)
            .IsRequired();

        builder.Property(x => x.Purpose)
            .HasMaxLength(500);

        builder.Property(x => x.Remarks)
            .HasMaxLength(1000);

        builder.Property(x => x.TenantId)
            .IsRequired()
            .HasMaxLength(64);

        // Relationships
        builder.HasMany<ICSItem>()
            .WithOne()
            .HasForeignKey(ii => ii.ICSId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.ICSNumber)
            .IsUnique();
        builder.HasIndex(x => x.TenantId);
        builder.HasIndex(x => x.CustodianId);

        // Soft delete filter
        builder.HasQueryFilter(x => x.DeletedOnUtc == null);
    }
}

public sealed class ICSItemConfiguration : IEntityTypeConfiguration<ICSItem>
{
    public void Configure(EntityTypeBuilder<ICSItem> builder)
    {
        builder.ToTable("ics_items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AssetId)
            .IsRequired();

        builder.Property(x => x.Remarks)
            .HasMaxLength(500);

        // Indexes
        builder.HasIndex(x => x.ICSId);
        builder.HasIndex(x => x.AssetId);
    }
}
