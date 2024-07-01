using CreativePlatform.Asset.Contracts;
using CreativePlatform.SharedKernel;
using MediatR;

namespace CreativePlatform.Order.Application;

internal class AssetCreatedIntegrationEventHandler(IEventBus eventBus, IBriefService service) : INotificationHandler<AssetCreatedIntegrationEvent>
{
    public async Task Handle(AssetCreatedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        if (notification.BriefId is null)
        {
            return;
        }

        await service.UpdateBriefWithAssetIdAsync(notification.BriefId, notification.AssetId, cancellationToken);
    }
}