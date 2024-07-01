using CreativePlatform.Content.Domain;
using CreativePlatform.Content.Infrastructure;

namespace CreativePlatform.Content.Application;

internal interface IContentService
{
    Task<ContentDto[]> GetDownloadableContentAsync(Guid campaignId);
    Task<ContentDto[]> GetDownloadableContentAsync(string orderNumber);

    Task UpdateAssetCampaignIdentifiersAsync(string assetId, Guid? campaignId, string orderNumber,
        CancellationToken cancellationToken = default);

    Task UpdateContentStatus(string assetId, CancellationToken cancellationToken);
}

internal class ContentService(ContentMapper mapper, IContentRepository repository) : IContentService
{
    public async Task<ContentDto[]> GetDownloadableContentAsync(Guid campaignId)
    {
        ContentResource[] content = await repository.GetContentByCampaignIdAsync(campaignId);
        return content.Select(mapper.ToContentDto).ToArray();
    }

    public async Task<ContentDto[]> GetDownloadableContentAsync(string orderNumber)
    {
        ContentResource[] content = await repository.GetContentByOrderNumberAsync(orderNumber);
        return content.Select(mapper.ToContentDto).ToArray();
    }

    public async Task UpdateAssetCampaignIdentifiersAsync(string assetId, Guid? campaignId, string orderNumber,
        CancellationToken cancellationToken = default)
    {
        ContentResource[] content = await repository.GetContentByAssetIdAsync(assetId, cancellationToken);
        foreach (ContentResource resource in content)
        {
            resource.CampaignId = campaignId;
            resource.OrderNumber = orderNumber;
        }

        await repository.BulkUpdateContentAsync(content, cancellationToken);
    }

    public async Task UpdateContentStatus(string assetId, CancellationToken cancellationToken)
    {
        ContentResource[] content = await repository.GetContentByAssetIdAsync(assetId, cancellationToken);

        foreach (ContentResource resource in content)
        {
            resource.Released = true;
        }

        await repository.BulkUpdateContentAsync(content, cancellationToken);
    }
}