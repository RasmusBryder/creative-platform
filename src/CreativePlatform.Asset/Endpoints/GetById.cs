using CreativePlatform.Asset.Application;
using FastEndpoints;

namespace CreativePlatform.Asset.Endpoints;

public record GetByIdRequest(string Id);

internal class GetById(IAssetService assetService) : Endpoint<GetByIdRequest, AssetDto>
{
    public override void Configure()
    {
        Get("/assets/{Id}");
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(GetByIdRequest req, CancellationToken ct)
    {
        AssetDto? result = await assetService.GetAsync(req.Id);

        if (result == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendAsync(result, cancellation: ct);
    }
}