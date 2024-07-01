using CreativePlatform.Content.Application;
using FastEndpoints;

namespace CreativePlatform.Content.Endpoints;

public record GetByCampaignIdRequest(Guid Id);

internal class GetByCampaignId(IContentService contentService)
    : Endpoint<GetByCampaignIdRequest, CampaignContentDto>
{
    public override void Configure()
    {
        Get("/campaigns/{Id}/content");
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(GetByCampaignIdRequest req, CancellationToken ct)
    {
        var content = await contentService.GetDownloadableContentAsync(req.Id);

        var result = new CampaignContentDto(content);

        await SendAsync(result, cancellation: ct);
    }
}

