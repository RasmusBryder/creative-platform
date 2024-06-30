using CreativePlatform.Content.Application;
using CreativePlatform.Content.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace CreativePlatform.Content;

public static class ContentServiceCollectionExtensions
{
    public static IServiceCollection AddContentModule(
        this IServiceCollection services,
        IConfiguration configuration,
        ILogger logger,
        List<Assembly> mediatrAssemblies)
    {
        services.AddScoped<IContentService, ContentService>();
        services.AddScoped<IContentRepository, ContentRepositoryStub>();
        services.AddSingleton<Application.ContentMapper>();
        mediatrAssemblies.Add(typeof(ContentServiceCollectionExtensions).Assembly);

        logger.Information("{Module} module services registered", "Content");
        return services;
    }
}