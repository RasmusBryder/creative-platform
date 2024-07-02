using CreativePlatform.Order.Application.Orders;
using CreativePlatform.Order.Contracts;
using MediatR;

namespace CreativePlatform.Order.Application.Events;

internal class OrderCreatedIntegrationEventHandler(IUserNotificationService service)
    : INotificationHandler<OrderCreatedIntegrationEvent>
{
    public async Task Handle(OrderCreatedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        await service.SendCreatedOrderNotification();
    }
}