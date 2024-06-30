using CreativePlatform.Asset.Application;
using CreativePlatform.Asset.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace CreativePlatform.Asset;

public static class AssetServiceCollectionExtensions
{
    public static IServiceCollection AddAssetModule(
        this IServiceCollection services,
        IConfiguration configuration,
        ILogger logger,
        List<Assembly> mediatrAssemblies)
    {
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<IAssetRepository, AssetRepositoryStub>();
        services.AddScoped<IDamRepository, DamRepositoryStub>();
        services.AddSingleton<Application.AssetMapper>();
        mediatrAssemblies.Add(typeof(AssetServiceCollectionExtensions).Assembly);

        logger.Information("{Module} module services registered", "Asset");
        return services;
    }
}