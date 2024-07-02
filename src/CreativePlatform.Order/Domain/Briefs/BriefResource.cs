namespace CreativePlatform.Order.Domain.Briefs;

public class BriefResource(string name)
{

    public Guid? CampaignId { get; set; }
    public string BriefId { get; set; } = string.Empty;
    public string OrderNumber { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string Name { get; set; } = name;
    public string? Description { get; set; }

    /// <summary>
    /// Set when brief is processed
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Set when brief is processed
    /// </summary>
    public DateTime? CreatedDate { get; set; }

    public string Status { get; set; } = BriefStatus.Pending;
    public string? Comments { get; set; }
    public string? AssetId { get; set; }
}