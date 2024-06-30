using CreativePlatform.Asset.Contracts;
using MediatR;

namespace CreativePlatform.Asset.Application;

internal class AssetDetailsByBriefIdQueryHandler(AssetMapper mapper, IAssetService service) : IRequestHandler<AssetDetailsByBriefIdQuery, AssetDetailsByBriefId>
{
    public async Task<AssetDetailsByBriefId> Handle(AssetDetailsByBriefIdQuery request, CancellationToken cancellationToken)
    {
        var assets = await service.GetByBriefIdsAsync(request.BriefIds);
        return new AssetDetailsByBriefId(assets.Select(mapper.ToAssetDetails).ToArray());
    }
}