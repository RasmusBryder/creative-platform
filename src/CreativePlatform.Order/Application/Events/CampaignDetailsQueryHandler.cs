using CreativePlatform.Order.Contracts;
using CreativePlatform.Order.Domain.Campaigns;
using CreativePlatform.Order.Infrastructure.Campaigns;
using MediatR;

namespace CreativePlatform.Order.Application.Events;

internal class CampaignDetailsQueryHandler(Campaigns.CampaignMapper mapper, ICampaignRepository repository)
    : IRequestHandler<CampaignDetailsQuery, CampaignDetails?>
{
    public async Task<CampaignDetails?> Handle(CampaignDetailsQuery request, CancellationToken cancellationToken)
    {
        CampaignResource? campaign = await repository.GetAsync(request.Id);

        return campaign is null ? null : mapper.ToCampaignDetails(campaign);
    }
}