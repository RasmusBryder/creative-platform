namespace CreativePlatform.Order.Domain;

/// <summary>
/// Constructors removed due to Bogus
/// </summary>
internal class OrderResource
{
    /// <summary>
    /// Is replaced by user name in final version.
    /// </summary>
    public string RequesterName { get; set; } = string.Empty;
    public Guid CampaignId { get; set; }
    public Guid OrderId { get; set; } = Guid.NewGuid();
    public string OrderNumber { get; set; } = string.Empty;
}