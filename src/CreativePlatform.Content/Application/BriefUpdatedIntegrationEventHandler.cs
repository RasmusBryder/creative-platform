using CreativePlatform.Order.Contracts;
using MediatR;

namespace CreativePlatform.Content.Application;

internal class BriefUpdatedIntegrationEventHandler(IContentService service)
    : INotificationHandler<BriefUpdatedIntegrationEvent>
{
    public async Task Handle(BriefUpdatedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        await service.UpdateAssetCampaignIdentifiersAsync(notification.AssetId, notification.CampaignId,
            notification.OrderNumber, cancellationToken);
    }
}