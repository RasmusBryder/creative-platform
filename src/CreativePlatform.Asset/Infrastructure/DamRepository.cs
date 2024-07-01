using CreativePlatform.Asset.Domain;

namespace CreativePlatform.Asset.Infrastructure;

internal interface IDamRepository
{
    /// <summary>
    /// Simplified understanding of upload. This method reflects a state when an asset has been uploaded and all metadata is ready.
    /// </summary>
    /// <param name="assetResource"></param>
    /// <returns></returns>
    Task<AssetDamMetadata> UploadAsset(Domain.AssetResource assetResource);
}

internal class DamRepositoryStub : IDamRepository
{
    public Task<AssetDamMetadata> UploadAsset(Domain.AssetResource assetResource)
    {
        return Task.FromResult(new AssetDamMetadata
        {
            Path = $"/path/to/{assetResource.AssetId.ToLower()}.{assetResource.FileFormat}",
            Preview = $"/path/to/preview/{assetResource.AssetId.ToLower()}_preview.{assetResource.FileFormat}"
        });
    }
}
