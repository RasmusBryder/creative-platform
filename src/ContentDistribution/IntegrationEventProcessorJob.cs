using CreativePlatform.SharedKernel;
using MediatR;

namespace ContentDistribution;

internal sealed class IntegrationEventProcessorJob(
    InMemoryMessageQueue queue,
    IServiceScopeFactory serviceScopeFactory,
    ILogger<IntegrationEventProcessorJob> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (IIntegrationEvent integrationEvent in
                       queue.Reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                using IServiceScope scope = serviceScopeFactory.CreateScope();

                var publisher = scope.ServiceProvider
                    .GetRequiredService<IPublisher>();

                await publisher.Publish(integrationEvent, stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "Something went wrong! {IntegrationEventId}",
                    integrationEvent.Id);
            }
        }
    }
}