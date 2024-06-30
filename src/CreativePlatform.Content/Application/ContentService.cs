using CreativePlatform.Content.Infrastructure;

namespace CreativePlatform.Content.Application;

internal interface IContentService
{
    Task<ContentDto[]> GetDownloadableContentAsync(IEnumerable<string> assetIds);
}

internal class ContentService(ContentMapper mapper, IContentRepository repository) : IContentService
{
    public async Task<ContentDto[]> GetDownloadableContentAsync(IEnumerable<string> assetIds)
    {
        var content = await repository.GetAssetUrls(assetIds);
        return content.Select(mapper.ToContentDto).ToArray();
    }
}

