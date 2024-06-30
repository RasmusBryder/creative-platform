using Bogus;

namespace CreativePlatform.Asset.Infrastructure;

internal interface IAssetRepository
{
    Task<Asset?> GetAsync(string id);
    Task<Asset> AddAsync(Asset asset);
    Task<Asset> UpdateAsync(Asset asset);
    Task<Asset[]> GetByBriefIdsAsync(string[] briefIds);
}

internal class AssetRepositoryStub : IAssetRepository
{
    public Task<Asset?> GetAsync(string id)
    {
        var extension = Faker.System.CommonFileExt();
        var customAssetFaker = AssetFaker.RuleFor(x => x.AssetId, id)
            .RuleFor(x => x.Path, _ => $"/path/to/{id.ToLower()}.{extension}")
            .RuleFor(x => x.Preview, _ => $"/path/to/preview/{id.ToLower()}_preview.{extension}");

        return Task.FromResult(customAssetFaker.Generate())!;
    }

    public Task<Asset> AddAsync(Asset asset)
    {
        var fakeAsset = AssetFaker.Generate();

        asset.AssetId = fakeAsset.AssetId;
        asset.VersionNumber = fakeAsset.VersionNumber;
        asset.Status = "Pending";
        return Task.FromResult(asset);
    }

    public Task<Asset> UpdateAsync(Asset asset)
    {
        return Task.FromResult(asset);
    }

    public Task<Asset[]> GetByBriefIdsAsync(string[] briefIds)
    {
        var assets = new List<Asset>();
        foreach (var briefId in briefIds)
        {
            var fakeAssets = AssetFaker.Generate(10);
            fakeAssets.ForEach(a => a.BriefId = briefId);
            assets.AddRange(fakeAssets);
        }
        return Task.FromResult(assets.ToArray());
    }

    private static Faker<Asset> AssetFaker => new AssetFaker();
    private static Faker Faker => new();

}