using MediatR;

namespace CreativePlatform.Order.Contracts;

public record CampaignBriefDetails(string BriefId);

public record CampaignBriefQuery(string CampaignId) : IRequest<CampaignBriefDetails[]>;