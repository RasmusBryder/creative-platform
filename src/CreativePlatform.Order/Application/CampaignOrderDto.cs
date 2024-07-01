namespace CreativePlatform.Order.Application;

/// <summary>
/// An order of campaign briefs made to the creatives.
/// </summary>
internal record OrderDto
{
    public Guid CampaignId { get; set; }
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public string RequesterName { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalBriefs => Briefs.Sum(b => b.Quantity);
    public List<CampaignOrderBriefDto> Briefs { get; set; }

    /// <summary>
    /// An order of campaign briefs made to the creatives.
    /// </summary>
    internal class CampaignOrderBriefDto
    {
        public string BriefId { get; set; }
        public int Quantity { get; set; }
    }
}