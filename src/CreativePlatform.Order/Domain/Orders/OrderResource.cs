namespace CreativePlatform.Order.Domain.Orders;

internal class OrderResource
{
    /// <summary>
    /// Is replaced by user name in final version.
    /// </summary>
    public string RequesterName { get; set; } = string.Empty;
    public Guid CampaignId { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OrderNumber { get; set; } = string.Empty;
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
}