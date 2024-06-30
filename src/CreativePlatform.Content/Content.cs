namespace CreativePlatform.Content;

public class Content(string assetId, string externalFileUrl)
{
    public string AssetId { get; set; } = assetId;
    public string ExternalFileUrl { get; set; } = externalFileUrl;
}