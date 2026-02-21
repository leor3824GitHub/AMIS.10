using FSH.Modules.SemiExpendableAssets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FSH.Playground.Migrations.PostgreSQL;

/// <summary>
/// Minimal DbContext for SemiExpendableAssets migrations at design-time only.
/// Does NOT inherit from BaseDbContext to simplify dependency resolution.
/// </summary>
public sealed class MigrationsSemiExpendableAssetsDbContext : DbContext
{
    public DbSet<SemiExpendableAsset> SemiExpendableAssets => Set<SemiExpendableAsset>();
    public DbSet<Receipt> Receipts => Set<Receipt>();
    public DbSet<ReceiptItem> ReceiptItems => Set<ReceiptItem>();
    public DbSet<ReturnDocument> ReturnDocuments => Set<ReturnDocument>();
    public DbSet<ReturnItem> ReturnItems => Set<ReturnItem>();
    public DbSet<TransferDocument> TransferDocuments => Set<TransferDocument>();
    public DbSet<TransferItem> TransferItems => Set<TransferItem>();
    public DbSet<InventoryCustodianSlip> InventoryCustodianSlips => Set<InventoryCustodianSlip>();
    public DbSet<AssetTransaction> AssetTransactions => Set<AssetTransaction>();
    public DbSet<ICSItem> ICSItems => Set<ICSItem>();

    public MigrationsSemiExpendableAssetsDbContext(DbContextOptions<MigrationsSemiExpendableAssetsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("semi_expendable_assets");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FSH.Modules.SemiExpendableAssets.Persistence.SemiExpendableAssetsDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var provider = configuration["DatabaseOptions:Provider"] ?? "POSTGRESQL";
            var connectionString = configuration["DatabaseOptions:ConnectionString"]
                ?? throw new InvalidOperationException("DatabaseOptions:ConnectionString is required in appsettings.json");
            var migrationsAssembly = configuration["DatabaseOptions:MigrationsAssembly"]
                ?? "FSH.Playground.Migrations.PostgreSQL";

            switch (provider.ToUpperInvariant())
            {
                case "POSTGRESQL":
                    optionsBuilder.UseNpgsql(
                        connectionString,
                        b => b.MigrationsAssembly(migrationsAssembly));
                    break;

                case "SQLSERVER":
                    optionsBuilder.UseSqlServer(
                        connectionString,
                        b => b.MigrationsAssembly(migrationsAssembly));
                    break;
            }
        }
    }
}

/// <summary>
/// Factory for design-time migration generation.
/// EF Core will use this to instantiate the context for migrations.
/// </summary>
public sealed class MigrationsSemiExpendableAssetsDbContextFactory : IDesignTimeDbContextFactory<MigrationsSemiExpendableAssetsDbContext>
{
    public MigrationsSemiExpendableAssetsDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var provider = configuration["DatabaseOptions:Provider"] ?? "POSTGRESQL";
        var connectionString = configuration["DatabaseOptions:ConnectionString"]
            ?? throw new InvalidOperationException("DatabaseOptions:ConnectionString is required in appsettings.json");
        var migrationsAssembly = configuration["DatabaseOptions:MigrationsAssembly"]
            ?? "FSH.Playground.Migrations.PostgreSQL";

        var optionsBuilder = new DbContextOptionsBuilder<MigrationsSemiExpendableAssetsDbContext>();
        
        switch (provider.ToUpperInvariant())
        {
            case "POSTGRESQL":
                optionsBuilder.UseNpgsql(
                    connectionString,
                    b => b.MigrationsAssembly(migrationsAssembly));
                break;
            case "SQLSERVER":
                optionsBuilder.UseSqlServer(
                    connectionString,
                    b => b.MigrationsAssembly(migrationsAssembly));
                break;
        }
        
        return new MigrationsSemiExpendableAssetsDbContext(optionsBuilder.Options);
    }
}
