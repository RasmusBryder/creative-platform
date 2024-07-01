namespace CreativePlatform.Content.Application;

internal class CampaignContentDto
{
    internal CampaignContentDto(
        ContentDto[] content)
    {
        Assets = content.Select(c => new DownloadableAssetDto(c.AssetId) { Name = c.Name, FileURL = c.ExternalFileUrl })
            .ToArray();
    }

    public DownloadableAssetDto[] Assets { get; }
}