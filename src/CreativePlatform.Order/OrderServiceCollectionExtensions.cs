using CreativePlatform.Order.Application;
using CreativePlatform.Order.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace CreativePlatform.Order;

public static class OrderServiceCollectionExtensions
{
    public static IServiceCollection AddOrderModule(
        this IServiceCollection services,
        IConfiguration configuration,
        ILogger logger,
        List<Assembly> mediatrAssemblies)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderRepository, OrderRepositoryStub>();
        services.AddScoped<IBriefService, BriefService>();
        services.AddScoped<IBriefRepository, BriefRepositoryStub>();
        services.AddScoped<ICampaignRepository, CampaignRepositoryStub>();
        services.AddScoped<IUserNotificationService, UserNotificationServiceStub>();
        services.AddSingleton<CampaignMapper>();
        services.AddSingleton<OrderMapper>();
        services.AddSingleton<BriefMapper>();
        mediatrAssemblies.Add(typeof(OrderServiceCollectionExtensions).Assembly);

        logger.Information("{Module} module services registered", "Order");
        return services;
    }
}