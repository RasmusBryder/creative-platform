using CreativePlatform.Asset.Contracts;
using CreativePlatform.Order.Application.Briefs;
using CreativePlatform.Order.Application.Orders;
using CreativePlatform.Order.Contracts;
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

internal class OrderCreatedIntegrationEventHandler(IUserNotificationService service)
    : INotificationHandler<OrderCreatedIntegrationEvent>
{
    public async Task Handle(OrderCreatedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        await service.SendCreatedOrderNotification();
    }
}