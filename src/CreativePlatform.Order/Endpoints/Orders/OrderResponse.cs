namespace CreativePlatform.Order.Endpoints.Orders;

public class OrderResponse(
    Guid id,
    Guid campaignId,
    string orderNumber,
    string requesterName,
    DateTimeOffset orderDate)
{
    public Guid Id { get; } = id;
    public Guid CampaignId { get; } = campaignId;
    public string? CampaignName { get; set; }
    public string OrderNumber { get; set; } = orderNumber;
    public string RequesterName { get; set; } = requesterName;
    public DateTimeOffset OrderDate { get; set; } = orderDate;
    public int TotalBriefs => Briefs.Sum(b => b.Quantity);
    public List<CampaignOrderBriefResponse> Briefs { get; set; } = [];

    public class CampaignOrderBriefResponse(string briefId)
    {
        public string BriefId { get; set; } = briefId;
        public int Quantity { get; set; }
    }
}