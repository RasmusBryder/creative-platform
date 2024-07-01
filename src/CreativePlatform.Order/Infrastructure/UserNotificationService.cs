using CreativePlatform.Order.Application;

namespace CreativePlatform.Order.Infrastructure;

internal class UserNotificationServiceStub : IUserNotificationService
{
    public Task SendCreatedOrderNotification()
    {
        return Task.CompletedTask;
    }
}
