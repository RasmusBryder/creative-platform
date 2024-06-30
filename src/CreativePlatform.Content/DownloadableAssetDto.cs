namespace CreativePlatform.Content;

internal class DownloadableAssetDto(string assetId)
{
    public string AssetId { get; set; } = assetId;

    public string? Name { get; set; }

    // Specify different property name
    public string? FileURL { get; set; }
}