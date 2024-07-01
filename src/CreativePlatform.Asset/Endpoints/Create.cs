using CreativePlatform.Asset.Application;
using FastEndpoints;

namespace CreativePlatform.Asset.Endpoints;

public record CreateAssetRequest
{
    public string? BriefId { get; set; }
    public string FileFormat { get; set; }
    public string FileSize { get; set; }
    public string Path { get; set; }
    public string CreatedBy { get; set; }
    public string UserName { get; set; }
    public string? Comments { get; set; }
    public string Preview { get; set; } // Could also be DAM reference
}

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