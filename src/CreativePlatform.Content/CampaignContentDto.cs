using CreativePlatform.Asset.Contracts;
using CreativePlatform.Campaign.Contracts;

namespace CreativePlatform.Content;

internal class CampaignContentDto
{
    internal CampaignContentDto(
        CampaignDetails campaign,
        AssetDetails[] assets,
        ContentDto[] content)
    {
        DistributionDate = campaign.DistributionDate;
        DistributionChannels = campaign.DistributionMethods;
        DistributionMethods = campaign.DistributionMethods;

        Assets = content.Select(c => new DownloadableAssetDto(c.AssetId)
            {
                Name = assets.FirstOrDefault(x => x.AssetId == c.AssetId)?.Name,
                FileURL = c.ExternalFileUrl
            })
            .ToArray();
    }

    public string DistributionDate { get; }
    public string[] DistributionChannels { get; }
    public string[] DistributionMethods { get; }
    public DownloadableAssetDto[] Assets { get; }
}