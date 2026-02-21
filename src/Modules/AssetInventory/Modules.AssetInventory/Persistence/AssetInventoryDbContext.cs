using Finbuckle.MultiTenant.Abstractions;
using FSH.Framework.Persistence;
using FSH.Framework.Persistence.Context;
using FSH.Framework.Shared.Multitenancy;
using FSH.Framework.Shared.Persistence;
using FSH.Modules.AssetInventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace FSH.Modules.AssetInventory.Persistence;

/// <summary>
/// DbContext for the AssetInventory module.
/// </summary>
public class AssetInventoryDbContext : BaseDbContext
{
    private readonly DatabaseOptions _settings;
    private new AppTenantInfo? TenantInfo { get; set; }
    private readonly IHostEnvironment _environment;

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

    public AssetInventoryDbContext(
        IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor,
        DbContextOptions<AssetInventoryDbContext> options,
        IOptions<DatabaseOptions> settings,
        IHostEnvironment environment) : base(multiTenantContextAccessor, options, settings, environment)
    {
        // Only validate in runtime context, not at design-time
        if (multiTenantContextAccessor != null && settings != null)
        {
            _environment = environment;
            _settings = settings.Value;
            TenantInfo = multiTenantContextAccessor.MultiTenantContext.TenantInfo;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("assetinventory");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssetInventoryDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (TenantInfo?.ConnectionString is not null)
        {
            optionsBuilder.ConfigureHeroDatabase(
                _settings.Provider,
                TenantInfo.ConnectionString,
                _settings.MigrationsAssembly,
                _environment.IsDevelopment());
        }
    }
}
