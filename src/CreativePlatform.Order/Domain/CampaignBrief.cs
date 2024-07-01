namespace CreativePlatform.Order.Domain;

/// <summary>
/// Constructors removed due to Bogus
/// </summary>
internal class CampaignBrief
{
    public Guid CampaignId { get; set; }
    public string BriefId { get; set; } = string.Empty;
    public string OrderNumber { get; set; }
    public int Quantity { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// Set when brief is processed
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Set when brief is processed
    /// </summary>
    public DateTime? CreatedDate { get; set; }

    public string Status { get; set; } = BriefStatus.Pending;
    public string Comments { get; set; } = string.Empty;
    public string? AssetId { get; set; }
}