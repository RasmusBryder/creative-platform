namespace CreativePlatform.Order.Application.Orders;

/// <summary>
/// An order of campaign briefs made to the creatives.
/// </summary>
internal class OrderDto(string orderNumber, string requesterName)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OrderNumber { get; } = orderNumber;
    public string RequesterName { get; } = requesterName;
    public Guid CampaignId { get; set; }
    public string? CampaignName { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public int TotalBriefs => Briefs.Sum(b => b.Quantity);
    public List<CampaignOrderBriefDto> Briefs { get; set; } = [];

    /// <summary>
    /// An order of campaign briefs made to the creatives.
    /// </summary>
    internal class CampaignOrderBriefDto(string briefId)
    {
        public string BriefId { get; set; } = briefId;
        public int Quantity { get; set; }
    }
}