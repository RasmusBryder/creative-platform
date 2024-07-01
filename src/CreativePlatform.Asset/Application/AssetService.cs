using CreativePlatform.Asset.Contracts;
using CreativePlatform.Asset.Infrastructure;
using CreativePlatform.SharedKernel;

namespace CreativePlatform.Asset.Application;

internal interface IAssetService
{
    Task<AssetDto> CreateAssetAsync(CreateAssetDto assetDto);
    Task<AssetDto?> GetAsync(string id);
}

internal class AssetService(IEventBus eventBus, IAssetRepository repository, IDamRepository damRepository, IUserRepository userRepository, AssetMapper mapper) : IAssetService
{
    public async Task<AssetDto> CreateAssetAsync(CreateAssetDto assetDto)
    {
        var asset = mapper.ToAsset(assetDto);
        var addedAsset = await repository.AddAsync(asset);

        // Upload asset, retrieve DAM paths
        var metadata = await damRepository.UploadAsset(addedAsset);

        asset.Path = metadata.Path;
        asset.Preview = metadata.Preview;
        var finalAsset = await repository.UpdateAsync(asset);

        await eventBus.PublishAsync(new AssetCreatedIntegrationEvent(Guid.NewGuid(),
            finalAsset.AssetId,
            finalAsset.BriefId,
            finalAsset.Path,
            finalAsset.Timestamp));
        
        var result = mapper.ToAssetDto(finalAsset);
        result.CreatedBy = userRepository.GetFullName(asset.UserName);
        return result;
    }

    public async Task<AssetDto?> GetAsync(string id)
    {
        var asset = await repository.GetAsync(id);
        if (asset is null)
        {
            return null;
        }

        var result = mapper.ToAssetDto(asset);
        result.CreatedBy = userRepository.GetFullName(asset.UserName);
        return result;
    }

}