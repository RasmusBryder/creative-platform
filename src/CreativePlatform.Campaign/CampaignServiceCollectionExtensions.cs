using CreativePlatform.Campaign.Application;
using CreativePlatform.Campaign.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace CreativePlatform.Campaign;

public static class CampaignServiceCollectionExtensions
{
    public static IServiceCollection AddCampaignModule(
        this IServiceCollection services,
        ILogger logger,
        List<Assembly> mediatrAssemblies)
    {
        services.AddScoped<ICampaignRepository, CampaignRepositoryStub>();
        services.AddSingleton<CampaignMapper>();
        mediatrAssemblies.Add(typeof(CampaignServiceCollectionExtensions).Assembly);

        logger.Information("{Module} module services registered", "Campaign");
        return services;
    }
}