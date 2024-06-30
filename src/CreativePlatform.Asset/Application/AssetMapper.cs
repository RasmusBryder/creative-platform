using CreativePlatform.Asset.Contracts;
using CreativePlatform.Asset.Endpoints;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Asset.Application;

[Mapper]
internal partial class AssetMapper
{
    public partial CreateAssetDto ToCreateAssetDto(CreateAssetRequest asset);
    public partial Asset ToAsset(CreateAssetDto asset);
    public partial AssetDto ToAssetDto(Asset asset);
    public partial AssetDetails ToAssetDetails(Asset asset);
    public partial AssetDetails ToAssetDetails(AssetDto asset);
}