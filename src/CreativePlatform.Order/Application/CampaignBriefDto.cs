namespace CreativePlatform.Order.Application;

/// <summary>
/// An order of campaign briefs made to the creatives.
/// </summary>
public record CampaignBriefDto
{
    public string BriefId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Status { get; set; }
    public string Comments { get; set; }
}