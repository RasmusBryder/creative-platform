using Bogus;
using CreativePlatform.Content.Domain;

namespace CreativePlatform.Content.Infrastructure;

internal interface IContentRepository
{
    Task<ContentResource[]> GetContentByCampaignIdAsync(Guid campaignId);
    Task<ContentResource[]> GetContentByOrderNumberAsync(string orderNumber);
    Task<ContentResource[]> GetContentByAssetIdAsync(string assetId, CancellationToken cancellationToken);
    Task BulkUpdateContentAsync(ContentResource[] content, CancellationToken cancellationToken);
}

internal class ContentRepositoryStub : IContentRepository
{
    private static readonly Faker Faker = new();

    public Task<ContentResource[]> GetContentByCampaignIdAsync(Guid campaignId)
    {
        return Task.FromResult(GenerateFakeContent().ToArray());
    }

    public Task<ContentResource[]> GetContentByOrderNumberAsync(string orderNumber)
    {
        return Task.FromResult(GenerateFakeContent().ToArray());
    }

    public Task<ContentResource[]> GetContentByAssetIdAsync(string assetId, CancellationToken cancellationToken)
    {
        return Task.FromResult(GenerateFakeContent().ToArray());
    }

    public Task BulkUpdateContentAsync(ContentResource[] content, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private static IEnumerable<ContentResource> GenerateFakeContent()
    {
        for (var i = 0; i < 10; i++)
        {
            var idSuffix = Faker.Random.Number(0, 99).ToString().PadLeft(2, '0');
            var assetId = $"ASSET0{idSuffix}";
            yield return new ContentResource(assetId,
                Faker.Commerce.ProductName(),
                $"https://example.com/assets/{assetId.ToLower()}.{Faker.System.CommonFileExt()}");
        }
    }
}