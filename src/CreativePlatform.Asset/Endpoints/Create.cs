using CreativePlatform.Asset.Application;
using FastEndpoints;

namespace CreativePlatform.Asset.Endpoints;

public record CreateAssetRequest(
    string Name,
    string Description,
    string? BriefId,
    string FileFormat,
    string FileSize,
    string UserName,
    string? Comments);

internal class Create(AssetMapper mapper, IAssetService assetService) : Endpoint<CreateAssetRequest, AssetDto>
{
    public override void Configure()
    {
        Post("/assets");
        AllowAnonymous(); // TODO: Set up authentication
    }

    public override async Task HandleAsync(CreateAssetRequest req, CancellationToken ct)
    {
        CreateAssetDto asset = mapper.ToCreateAssetDto(req);

        AssetDto createdAsset = await assetService.CreateAssetAsync(asset);
        await SendCreatedAtAsync<GetById>(new { createdAsset.AssetId }, createdAsset, cancellation: ct);
    }
}