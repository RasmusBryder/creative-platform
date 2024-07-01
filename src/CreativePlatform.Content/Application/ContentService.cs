using CreativePlatform.Content.Infrastructure;

namespace CreativePlatform.Content.Application;

internal interface IContentService
{
    Task<ContentDto[]> GetDownloadableContentAsync(Guid campaignId);
    Task<ContentDto[]> GetDownloadableContentAsync(string orderNumber);
    Task UpdateAssetCampaignIdentifiersAsync(string assetId, Guid campaignId, string orderNumber, CancellationToken cancellationToken = default);
}

internal class ContentService(ContentMapper mapper, IContentRepository repository) : IContentService
{
    public async Task<ContentDto[]> GetDownloadableContentAsync(Guid campaignId)
    {
        var content = await repository.GetContentByCampaignIdAsync(campaignId);
        return content.Select(mapper.ToContentDto).ToArray();
    }

    public async Task<ContentDto[]> GetDownloadableContentAsync(string orderNumber)
    {
        var content = await repository.GetContentByOrderNumberAsync(orderNumber);
        return content.Select(mapper.ToContentDto).ToArray();
    }

    public async Task UpdateAssetCampaignIdentifiersAsync(string assetId, Guid campaignId, string orderNumber, CancellationToken cancellationToken = default)
    {
        var content = await repository.GetContentByAssetIdAsync(assetId, cancellationToken);
        foreach (var resource in content)
        {
            resource.CampaignId = campaignId;
            resource.OrderNumber = orderNumber;
        }

        await repository.BulkUpdateContentAsync(content, cancellationToken);
    }
}

