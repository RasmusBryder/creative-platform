using CreativePlatform.Campaign.Application;
using CreativePlatform.Campaign.Infrastructure;
using FastEndpoints;

namespace CreativePlatform.Campaign.Endpoints;

public record GetByIdRequest(Guid Id);

internal class GetById(CampaignMapper mapper, ICampaignRepository campaignRepository)
    : Endpoint<GetByIdRequest, CampaignDto>
{
    public override void Configure()
    {
        Get("/campaigns/{Id}");
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(GetByIdRequest req, CancellationToken ct)
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

