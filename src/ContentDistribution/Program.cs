using CreativePlatform.Asset;
using CreativePlatform.Campaign;
using CreativePlatform.Content;
using CreativePlatform.Order;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Serilog;
using System.Reflection;
using ILogger = Serilog.ILogger;

ILogger logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((_, config) =>
    config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddFastEndpoints()
    .AddAuthenticationJwtBearer(s => s.SigningKey = "The secret used to sign tokens")
    .AddAuthorization()
    .SwaggerDocument();

List<Assembly> mediatrAssemblies = [typeof(ContentDistribution.Program).Assembly];
builder.Services
    .AddCampaignModule(logger, mediatrAssemblies)
    .AddOrderModule(builder.Configuration, logger, mediatrAssemblies)
    .AddAssetModule(builder.Configuration, logger, mediatrAssemblies)
    .AddContentModule(builder.Configuration, logger, mediatrAssemblies);

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(mediatrAssemblies.ToArray()));

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseAuthentication()
    .UseAuthorization();

app.UseFastEndpoints()
    .UseSwaggerGen(); //add this

app.Run();

namespace ContentDistribution
{
    public class Program
    {
    }
} // needed for tests