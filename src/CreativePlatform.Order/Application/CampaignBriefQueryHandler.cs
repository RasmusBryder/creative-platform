using CreativePlatform.Order.Contracts;
using MediatR;

namespace CreativePlatform.Order.Application;

internal class CampaignBriefQueryHandler(BriefMapper mapper, IBriefService service) : IRequestHandler<CampaignBriefQuery, CampaignBriefDetails[]>
{
    public async Task<CampaignBriefDetails[]> Handle(CampaignBriefQuery request, CancellationToken cancellationToken)
    {
        var briefs = await service.GetBriefsByCampaignIdAsync(request.CampaignId);

        return briefs.Select(mapper.ToBriefDetails).ToArray();
    }
}