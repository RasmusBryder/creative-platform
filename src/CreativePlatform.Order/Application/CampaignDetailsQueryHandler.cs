using CreativePlatform.Order.Contracts;
using CreativePlatform.Order.Domain;
using CreativePlatform.Order.Infrastructure;
using MediatR;

namespace CreativePlatform.Order.Application;

internal class CampaignDetailsQueryHandler(CampaignMapper mapper, ICampaignRepository repository)
    : IRequestHandler<CampaignDetailsQuery, CampaignDetails?>
{
    public async Task<CampaignDetails?> Handle(CampaignDetailsQuery request, CancellationToken cancellationToken)
    {
        CampaignResource? campaign = await repository.GetAsync(request.Id);

        return campaign is null ? null : mapper.ToCampaignDetails(campaign);
    }
}