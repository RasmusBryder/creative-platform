using CreativePlatform.Asset.Contracts;
using CreativePlatform.Asset.Infrastructure;
using CreativePlatform.SharedKernel;

namespace CreativePlatform.Asset.Application;

internal interface IAssetService
{
    Task<AssetDto> CreateAssetAsync(CreateAssetDto assetDto);
    Task<AssetDto?> GetAsync(string id);
    Task<AssetDto[]> GetByBriefIdsAsync(string[] briefIds);
}

internal class AssetService(IEventBus eventBus, IAssetRepository repository, IDamRepository damRepository, AssetMapper mapper) : IAssetService
{
    public async Task<AssetDto> CreateAssetAsync(CreateAssetDto assetDto)
    {
        // TODO: Add brief data
        var asset = mapper.ToAsset(assetDto);
        var addedAsset = await repository.AddAsync(asset);

        // Upload asset, retrieve DAM paths
        var metadata = await damRepository.UploadAsset(addedAsset);

        asset.Path = metadata.Path;
        asset.Preview = metadata.Preview;
        var finalAsset = await repository.UpdateAsync(asset);

        await eventBus.PublishAsync(new AssetCreatedIntegrationEvent(Guid.NewGuid(), finalAsset.AssetId, finalAsset.BriefId, finalAsset.Path));
        return mapper.ToAssetDto(finalAsset);
    }

    public async Task<AssetDto?> GetAsync(string id)
    {
        var asset = await repository.GetAsync(id);
        return asset is null ? null : mapper.ToAssetDto(asset);
    }

    public async Task<AssetDto[]> GetByBriefIdsAsync(string[] briefIds)
    {
        var assets = await repository.GetByBriefIdsAsync(briefIds);
        return assets.Select(mapper.ToAssetDto).ToArray();
    }
}