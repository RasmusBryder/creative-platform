using CreativePlatform.Asset.Contracts;
using CreativePlatform.Order.Application.Briefs;
using MediatR;

namespace CreativePlatform.Order.Application.Events;

internal class AssetCreatedIntegrationEventHandler(IBriefService service)
    : INotificationHandler<AssetCreatedIntegrationEvent>
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