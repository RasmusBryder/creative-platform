using CreativePlatform.Asset.Domain;
using CreativePlatform.Asset.Endpoints;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Asset.Application;

[Mapper]
internal partial class AssetMapper
{
    public partial CreateAssetDto ToCreateAssetDto(CreateAssetRequest asset);
    public partial AssetResource ToAsset(CreateAssetDto asset);
    public partial AssetDto ToAssetDto(Domain.AssetResource assetResource);
}