using CreativePlatform.Asset.Contracts;
using CreativePlatform.Asset.Infrastructure;
using MediatR;

namespace CreativePlatform.Asset.Application;

internal class AssetQueryHandler(AssetMapper mapper, IAssetRepository repository) : IRequestHandler<AssetDetailsByBriefIdQuery, AssetDetailsByBriefId>
{
    public async Task<AssetDetailsByBriefId> Handle(AssetDetailsByBriefIdQuery request, CancellationToken cancellationToken)
    {
        var assets = await repository.GetByBriefIdsAsync(request.BriefIds);

        return new AssetDetailsByBriefId(assets.Select(mapper.ToAssetDetails).ToArray());
    }
}