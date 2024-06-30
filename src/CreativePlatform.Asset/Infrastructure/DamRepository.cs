namespace CreativePlatform.Asset.Infrastructure;

internal interface IDamRepository
{
    /// <summary>
    /// Simplified understanding of upload. This method reflects a state when an asset has been uploaded and all metadata is ready.
    /// </summary>
    /// <param name="asset"></param>
    /// <returns></returns>
    Task<AssetDamMetadata> UploadAsset(Asset asset);
}

internal class DamRepositoryStub : IDamRepository
{
    public Task<AssetDamMetadata> UploadAsset(Asset asset)
    {
        return Task.FromResult(new AssetDamMetadata
        {
            Path = $"/path/to/{asset.AssetId.ToLower()}.{asset.FileFormat}",
            Preview = $"/path/to/preview/{asset.AssetId.ToLower()}_preview.{asset.FileFormat}"
        });
    }
}
