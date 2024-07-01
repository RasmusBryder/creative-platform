namespace CreativePlatform.Content.Domain;

public class ContentResource(string assetId, string name, string externalFileUrl)
{
    public string AssetId { get; set; } = assetId;
    public string Name { get; set; } = name;
    public string ExternalFileUrl { get; set; } = externalFileUrl;
    public Guid? CampaignId { get; set; }
    public string? OrderNumber { get; set; }
    public bool Released { get; set; } = false;
}