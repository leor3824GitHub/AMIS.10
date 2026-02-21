using FSH.Framework.Persistence;
using FSH.Framework.Persistence.Context;
using FSH.Framework.Shared.Multitenancy;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.SemiExpendableAssets.Domain;
using Finbuckle.MultiTenant.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace FSH.Modules.SemiExpendableAssets.Persistence;

public class SemiExpendableAssetsDbContext : BaseDbContext
{
    public SemiExpendableAssetsDbContext(
        IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor,
        DbContextOptions<SemiExpendableAssetsDbContext> options,
        IOptions<DatabaseOptions> settings,
        IHostEnvironment environment)
        : base(multiTenantContextAccessor, options, settings, environment)
    {
    }

    public DbSet<SemiExpendableAsset> SemiExpendableAssets => Set<SemiExpendableAsset>();
    public DbSet<AssetTransaction> AssetTransactions => Set<AssetTransaction>();
    public DbSet<Receipt> Receipts => Set<Receipt>();
    public DbSet<ReceiptItem> ReceiptItems => Set<ReceiptItem>();
    public DbSet<InventoryCustodianSlip> InventoryCustodianSlips => Set<InventoryCustodianSlip>();
    public DbSet<ICSItem> ICSItems => Set<ICSItem>();
    public DbSet<ReturnDocument> ReturnDocuments => Set<ReturnDocument>();
    public DbSet<ReturnItem> ReturnItems => Set<ReturnItem>();
    public DbSet<TransferDocument> TransferDocuments => Set<TransferDocument>();
    public DbSet<TransferItem> TransferItems => Set<TransferItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("semi_expendable_assets");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SemiExpendableAssetsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
