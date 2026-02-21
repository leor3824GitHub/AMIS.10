namespace FSH.Modules.Library;

/// <summary>
/// Extension methods for registering the Library module.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Adds the Library module to the dependency injection container.
    /// </summary>
    public static IServiceCollection AddLibraryModule(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<LibraryDbContext>((sp, options) =>
        {
            var settings = sp.GetRequiredService<IOptions<DatabaseOptions>>().Value;
            var isDevelopment = sp.GetRequiredService<IHostEnvironment>().IsDevelopment();
            options.ConfigureHeroDatabase(
                settings.Provider,
                settings.ConnectionString!,
                settings.MigrationsAssembly,
                isDevelopment);
        });

        services.AddScoped<IDbInitializer, LibraryDbInitializer>();

        return services;
    }

    /// <summary>
    /// Maps all Library module endpoints to the application.
    /// </summary>
    public static IEndpointRouteBuilder MapLibraryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var root = endpoints.MapGroup("/api/v1/library")
            .WithTags("Library");

        // Employee endpoints
        var employees = root.MapGroup("/employees")
            .WithTags("Employees");
        CreateEmployeeEndpoint.Map(employees);
        GetEmployeeEndpoint.Map(employees);
        GetAllEmployeesEndpoint.Map(employees);
        UpdateEmployeeEndpoint.Map(employees);
        DeleteEmployeeEndpoint.Map(employees);

        // Office endpoints
        var offices = root.MapGroup("/offices")
            .WithTags("Offices");
        CreateOfficeEndpoint.Map(offices);
        GetOfficeEndpoint.Map(offices);
        GetAllOfficesEndpoint.Map(offices);
        UpdateOfficeEndpoint.Map(offices);
        DeleteOfficeEndpoint.Map(offices);

        // Supplier endpoints
        var suppliers = root.MapGroup("/suppliers")
            .WithTags("Suppliers");
        CreateSupplierEndpoint.Map(suppliers);
        GetSupplierByIdEndpoint.Map(suppliers);
        GetAllSuppliersEndpoint.Map(suppliers);
        UpdateSupplierEndpoint.Map(suppliers);
        DeleteSupplierEndpoint.Map(suppliers);

        // Asset Category endpoints
        var categories = root.MapGroup("/asset-categories")
            .WithTags("Asset Categories");
        CreateAssetCategoryEndpoint.Map(categories);
        GetAssetCategoryByIdEndpoint.Map(categories);
        GetAllAssetCategoriesEndpoint.Map(categories);
        UpdateAssetCategoryEndpoint.Map(categories);
        DeleteAssetCategoryEndpoint.Map(categories);

        return endpoints;
    }
}
