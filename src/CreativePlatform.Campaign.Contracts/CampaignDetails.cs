using MediatR;

namespace CreativePlatform.Campaign.Contracts;

public class CampaignDetails {

    public string Id { get; set; }
    public string DistributionDate { get; set; }
    public string[] DistributionChannels { get; set; }
    public string[] DistributionMethods { get; set; }
}

public record CampaignDetailsQuery(string Id) : IRequest<CampaignDetails?>;