namespace CreativePlatform.Order.Application.Orders;

internal interface IUserNotificationService
{
    Task SendCreatedOrderNotification();
}