using Bogus;

namespace CreativePlatform.Content.Infrastructure;

internal interface IContentRepository
{
    Task<Content[]> GetAssetUrls(IEnumerable<string> assetIds);
}

internal class ContentRepositoryStub : IContentRepository
{
    public Task<Content[]> GetAssetUrls(IEnumerable<string> assetIds)
    {
        return Task.FromResult(assetIds.Select(assetId => new Content(assetId, $"https://example.com/assets/{assetId}.{Faker.System.CommonFileExt()}")).ToArray());
    }

    private static readonly Faker Faker = new();
}