using FSH.Framework.Shared.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FSH.Modules.AssetInventory.Persistence;

/// <summary>
/// Design-time factory for AssetInventoryDbContext.
/// Used by EF Core CLI for migrations without requiring runtime service configuration.
/// </summary>
public sealed class AssetInventoryDbContextFactory : IDesignTimeDbContextFactory<AssetInventoryDbContext>
{
    public AssetInventoryDbContext CreateDbContext(string[] args)
    {
        // Design-time: read configuration to determine database provider and connection string
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var provider = configuration["DatabaseOptions:Provider"] ?? "POSTGRESQL";
        var connectionString = configuration["DatabaseOptions:ConnectionString"]
            ?? "Host=localhost;Database=amis;Username=postgres;Password=postgres";
        var migrationsAssembly = configuration["DatabaseOptions:MigrationsAssembly"]
            ?? "FSH.Playground.Migrations.PostgreSQL";

        var optionsBuilder = new DbContextOptionsBuilder<AssetInventoryDbContext>();

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

            default:
                throw new NotSupportedException($"Database provider '{provider}' is not supported for AssetInventoryDbContext migrations.");
        }

        // Return the design-time context that inherits from AssetInventoryDbContext
        return new DesignTimeAssetInventoryDbContext(optionsBuilder.Options);
    }

    /// <summary>
    /// Minimal design-time context that can be instantiated without full dependency resolution.
    /// </summary>
    private sealed class DesignTimeAssetInventoryDbContext : AssetInventoryDbContext
    {
        public DesignTimeAssetInventoryDbContext(DbContextOptions<AssetInventoryDbContext> options)
            : base(
                multiTenantContextAccessor: null!,
                options,
                settings: null!,
                environment: null!)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base implementation to apply all configurations
            base.OnModelCreating(modelBuilder);
        }
    }
}
