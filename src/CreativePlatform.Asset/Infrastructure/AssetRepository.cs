using Bogus;
using CreativePlatform.Asset.Domain;

namespace CreativePlatform.Asset.Infrastructure;

internal interface IAssetRepository
{
    Task<AssetResource?> GetAsync(string id);
    Task<AssetResource> AddAsync(AssetResource assetResource);
    Task<AssetResource> UpdateAsync(AssetResource assetResource);
    Task<AssetResource[]> GetByBriefIdsAsync(string[] briefIds);
}

internal class AssetRepositoryStub : IAssetRepository
{
    public Task<AssetResource?> GetAsync(string id)
    {
        var extension = Faker.System.CommonFileExt();
        var customAssetFaker = AssetFaker.RuleFor(x => x.AssetId, id)
            .RuleFor(x => x.Path, _ => $"/path/to/{id.ToLower()}.{extension}")
            .RuleFor(x => x.Preview, _ => $"/path/to/preview/{id.ToLower()}_preview.{extension}");

        return Task.FromResult(customAssetFaker.Generate())!;
    }

    public Task<AssetResource> AddAsync(AssetResource assetResource)
    {
        var fakeAsset = AssetFaker.Generate();

        assetResource.AssetId = fakeAsset.AssetId;
        assetResource.VersionNumber = fakeAsset.VersionNumber;
        assetResource.Status = "Pending";
        return Task.FromResult(assetResource);
    }

    public Task<AssetResource> UpdateAsync(AssetResource assetResource)
    {
        return Task.FromResult(assetResource);
    }

    public Task<AssetResource[]> GetByBriefIdsAsync(string[] briefIds)
    {
        var assets = new List<AssetResource>();
        foreach (var briefId in briefIds)
        {
            var fakeAssets = AssetFaker.Generate(10);
            fakeAssets.ForEach(a => a.BriefId = briefId);
            assets.AddRange(fakeAssets);
        }
        return Task.FromResult(assets.ToArray());
    }

    private static Faker<AssetResource> AssetFaker => new AssetFaker();
    private static Faker Faker => new();

}