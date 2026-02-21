using FSH.Framework.Persistence;
using FSH.Framework.Web.Modules;
using FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Create;
using FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Delete;
using FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.GetAll;
using FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.GetById;
using FSH.Modules.AssetInventory.Features.v1.PhysicalAssets.Update;
using FSH.Modules.AssetInventory.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FSH.Modules.AssetInventory;

/// <summary>
/// AssetInventory module providing PPE inventory management capabilities.
/// </summary>
public sealed class AssetInventoryModule : IModule
{
    public void ConfigureServices(IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        // Register DbContext
        builder.Services.AddHeroDbContext<AssetInventoryDbContext>();
    }

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var group = endpoints.MapGroup("/api/v1/physical-assets").WithTags("Physical Assets");

        group.MapPost("/", CreatePhysicalAssetEndpoint.Map);
        group.MapGet("/", GetAllPhysicalAssetsEndpoint.Map);
        group.MapGet("/{id}", GetPhysicalAssetEndpoint.Map);
        group.MapPut("/{id}", UpdatePhysicalAssetEndpoint.Map);
        group.MapDelete("/{id}", DeletePhysicalAssetEndpoint.Map);
    }
}
