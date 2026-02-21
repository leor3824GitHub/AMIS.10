using FSH.Framework.Persistence;
using FSH.Framework.Web.Modules;
using FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Create;
using FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Delete;
using FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.GetAll;
using FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.GetById;
using FSH.Modules.SemiExpendableAssets.Features.v1.SemiExpendableAssets.Update;
using FSH.Modules.SemiExpendableAssets.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FSH.Modules.SemiExpendableAssets;

/// <summary>SemiExpendableAssets module for managing semi-expendable property inventory.</summary>
public sealed class SemiExpendableAssetsModule : IModule
{
    public void ConfigureServices(IHostApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddHeroDbContext<SemiExpendableAssetsDbContext>();
    }

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var group = endpoints
            .MapGroup("/api/v1/semi-expendable-assets")
            .WithTags("Semi-Expendable Assets");

        group.MapPost("/", CreateSemiExpendableAssetEndpoint.Map);
        group.MapGet("/", GetAllSemiExpendableAssetsEndpoint.Map);
        group.MapGet("/{id}", GetSemiExpendableAssetEndpoint.Map);
        group.MapPut("/{id}", UpdateSemiExpendableAssetEndpoint.Map);
        group.MapDelete("/{id}", DeleteSemiExpendableAssetEndpoint.Map);
    }
}
