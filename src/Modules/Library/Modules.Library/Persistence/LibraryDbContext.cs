namespace FSH.Modules.Library.Persistence;

/// <summary>
/// Database context for Library Module (Reference Data).
/// Contains shared entities used across multiple modules.
/// </summary>
public class LibraryDbContext(IMultiTenantContextAccessor<AppTenantInfo> multiTenantContextAccessor,
    DbContextOptions<LibraryDbContext> options,
    IOptions<DatabaseOptions> settings,
    IHostEnvironment environment)
    : BaseDbContext(multiTenantContextAccessor, options, settings, environment)
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Office> Offices => Set<Office>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<AssetCategory> Categories => Set<AssetCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("library");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
