using CreativePlatform.Order.Application;
using CreativePlatform.Order.Application.Orders;

namespace CreativePlatform.Order.Infrastructure.Notifications;

internal class UserNotificationServiceStub : IUserNotificationService
{
    public Task SendCreatedOrderNotification()
    {
        return Task.CompletedTask;
    }
}
