using FSH.Modules.AssetInventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FSH.Playground.Migrations.PostgreSQL;

/// <summary>
/// Minimal DbContext for AssetInventory migrations at design-time only.
/// Does NOT inherit from BaseDbContext to simplify dependency resolution.
/// </summary>
public sealed class MigrationsAssetInventoryDbContext : DbContext
{
    public DbSet<PhysicalAsset> PhysicalAssets => Set<PhysicalAsset>();
    public DbSet<AssetTransaction> AssetTransactions => Set<AssetTransaction>();
    public DbSet<PPERR> PPERRs => Set<PPERR>();
    public DbSet<PPERRItem> PPERRItems => Set<PPERRItem>();
    public DbSet<PAR> PARs => Set<PAR>();
    public DbSet<PARItem> PARItems => Set<PARItem>();
    public DbSet<RRP> RRPs => Set<RRP>();
    public DbSet<RRPItem> RRPItems => Set<RRPItem>();
    public DbSet<PPEIR> PPEIRs => Set<PPEIR>();
    public DbSet<PPEIRItem> PPEIRItems => Set<PPEIRItem>();

    public MigrationsAssetInventoryDbContext(DbContextOptions<MigrationsAssetInventoryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("assetinventory");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FSH.Modules.AssetInventory.Persistence.AssetInventoryDbContext).Assembly);
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
public sealed class MigrationsAssetInventoryDbContextFactory : IDesignTimeDbContextFactory<MigrationsAssetInventoryDbContext>
{
    public MigrationsAssetInventoryDbContext CreateDbContext(string[] args)
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

        var optionsBuilder = new DbContextOptionsBuilder<MigrationsAssetInventoryDbContext>();
        
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
        
        return new MigrationsAssetInventoryDbContext(optionsBuilder.Options);
    }
}
