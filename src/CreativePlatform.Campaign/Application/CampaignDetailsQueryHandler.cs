using CreativePlatform.Campaign.Contracts;
using CreativePlatform.Campaign.Infrastructure;
using MediatR;

namespace CreativePlatform.Campaign.Application;

internal class CampaignDetailsQueryHandler(CampaignMapper mapper, ICampaignRepository repository) : IRequestHandler<CampaignDetailsQuery, CampaignDetails?>
{
    public async Task<CampaignDetails?> Handle(CampaignDetailsQuery request, CancellationToken cancellationToken)
    {
        var campaign = await repository.GetAsync(request.Id);

        return campaign is null ? null : mapper.ToCampaignDetails(campaign);
    }
}