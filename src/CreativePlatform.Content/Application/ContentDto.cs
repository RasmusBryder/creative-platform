namespace CreativePlatform.Content.Application;

public class ContentDto(string assetId, string externalFileUrl)
{
    public string AssetId { get; set; } = assetId;
    public string? Name { get; set; }

    // Is updated
    public string ExternalFileUrl { get; set; } = externalFileUrl;
}