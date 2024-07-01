using CreativePlatform.Order.Contracts;
using MediatR;

namespace CreativePlatform.Content.Application;

internal class BriefReleasedIntegrationEventHandler(IContentService service)
    : INotificationHandler<BriefReleasedIntegrationEvent>
{
    public async Task Handle(BriefReleasedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        await service.UpdateContentStatus(notification.AssetId, cancellationToken);
    }
}