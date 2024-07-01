namespace CreativePlatform.Order.Application;

internal interface IUserNotificationService
{
    Task SendCreatedOrderNotification();
}