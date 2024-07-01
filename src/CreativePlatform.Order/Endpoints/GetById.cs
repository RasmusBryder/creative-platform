using CreativePlatform.Order.Application;
using CreativePlatform.Order.Infrastructure;
using FastEndpoints;

namespace CreativePlatform.Order.Endpoints;

public record GetCampaignByIdRequest(Guid Id);

internal class GetCampaignById(CampaignMapper mapper, ICampaignRepository campaignRepository)
    : Endpoint<GetCampaignByIdRequest, CampaignDto>
{
    public override void Configure()
    {
        Get("/campaigns/{Id}");
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(GetCampaignByIdRequest req, CancellationToken ct)
    {
        var campaign = await campaignRepository.GetAsync(req.Id);

        if (campaign is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var result = mapper.ToCampaignDto(campaign);

        await SendAsync(result, cancellation: ct);
    }
}

