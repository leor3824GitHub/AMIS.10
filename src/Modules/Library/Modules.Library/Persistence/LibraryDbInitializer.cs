namespace FSH.Modules.Library.Persistence;

/// <summary>
/// Database initializer for Library module.
/// </summary>
public class LibraryDbInitializer(LibraryDbContext context) : IDbInitializer
{
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        if ((await context.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            await context.Database.MigrateAsync(cancellationToken);
        }
    }

    public async Task ResetAsync(CancellationToken cancellationToken)
    {
        if (await context.Database.CanConnectAsync(cancellationToken))
        {
            await context.Database.EnsureDeletedAsync(cancellationToken);
        }
    }

    public async Task MigrateAsync(CancellationToken cancellationToken) =>
        await InitializeAsync(cancellationToken);

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        // Seed initialized through migrations if needed
        await Task.CompletedTask;
    }
}
