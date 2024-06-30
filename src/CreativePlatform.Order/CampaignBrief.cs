namespace CreativePlatform.Order;

/// <summary>
/// Constructors removed due to Bogus
/// </summary>
internal class CampaignBrief
{
    public string BriefId { get; set; } = string.Empty;
    public Guid OrderId { get; set; } = Guid.NewGuid();
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
}