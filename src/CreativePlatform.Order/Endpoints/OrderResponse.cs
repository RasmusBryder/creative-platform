namespace CreativePlatform.Order.Endpoints;

public class OrderResponse
{
    public Guid CampaignId { get; set; }
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public string RequesterName { get; set; }
    public DateTime OrderDate { get; set; }
    public string CampaignName { get; set; }
    public int TotalBriefs => Briefs.Sum(b => b.Quantity);
    public List<CampaignOrderBriefResponse> Briefs { get; set; }

    public class CampaignOrderBriefResponse
    {
        public string BriefId { get; set; }
        public int Quantity { get; set; }
    }
}