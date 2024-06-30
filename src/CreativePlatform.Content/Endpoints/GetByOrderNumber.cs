using CreativePlatform.Asset.Contracts;
using CreativePlatform.Campaign.Contracts;
using CreativePlatform.Content.Application;
using CreativePlatform.Order.Contracts;
using FastEndpoints;
using MediatR;

namespace CreativePlatform.Content.Endpoints;

public record GetByOrderNumberRequest(string OrderNumber);

internal class GetByOrderNumber(IContentService contentService, IMediator mediator)
    : Endpoint<GetByOrderNumberRequest, CampaignContentDto>
{
    public override void Configure()
    {
        Get("/orders/{OrderNumber}/content"); // Should probably depend on campaign ID
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(GetByOrderNumberRequest req, CancellationToken ct)
    {
        // TODO: Needs to be handled differently, using events
        var orderQuery = new OrderDetailsQuery(req.OrderNumber);
        OrderDetails? order = await mediator.Send(orderQuery, ct);
        
        if (order == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var campaignQuery = new CampaignDetailsQuery(order.CampaignId);
        var campaign = await mediator.Send(campaignQuery, ct);

        if (campaign == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var assetDetails = await mediator.Send(new AssetDetailsByBriefIdQuery(order.BriefIds), ct);
        var content = await contentService.GetDownloadableContentAsync(assetDetails.Assets.Select(x => x.AssetId));
        
        var result = new CampaignContentDto(campaign, assetDetails.Assets, content);

        await SendAsync(result, cancellation: ct);
    }
}

