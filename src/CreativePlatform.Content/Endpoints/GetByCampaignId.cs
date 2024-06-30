using CreativePlatform.Asset.Contracts;
using CreativePlatform.Campaign.Contracts;
using CreativePlatform.Content.Application;
using CreativePlatform.Order.Contracts;
using FastEndpoints;
using MediatR;

namespace CreativePlatform.Content.Endpoints;

public record GetByCampaignIdRequest(string CampaignId);

internal class GetByCampaignId(IContentService contentService, IMediator mediator)
    : Endpoint<GetByCampaignIdRequest, CampaignContentDto>
{
    public override void Configure()
    {
        Get("/campaigns/{CampaignId}/content"); // Should probably depend on campaign ID
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(GetByCampaignIdRequest req, CancellationToken ct)
    {
        // TODO: Needs to be handled differently, using events
        var briefsTask = mediator.Send(new CampaignBriefQuery(req.CampaignId), ct);
        var campaignTask = mediator.Send(new CampaignDetailsQuery(req.CampaignId), ct);

        var briefs = await briefsTask;
        var assetDetails = await mediator.Send(new AssetDetailsByBriefIdQuery(briefs.Select(x => x.BriefId).ToArray()), ct);
        var content = await contentService.GetDownloadableContentAsync(assetDetails.Assets.Select(x => x.AssetId));
        var campaign = await campaignTask;

        if (campaign == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var result = new CampaignContentDto(campaign, assetDetails.Assets, content);

        await SendAsync(result, cancellation: ct);
    }
}

