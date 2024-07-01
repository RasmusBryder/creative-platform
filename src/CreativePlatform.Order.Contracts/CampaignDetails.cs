using MediatR;

namespace CreativePlatform.Order.Contracts;

public class CampaignDetails
{
    public Guid Id { get; set; }
    public string? DistributionDate { get; set; }
    public string[] DistributionChannels { get; set; } = [];
    public string[] DistributionMethods { get; set; } = [];
}

/// <summary>
///     For extraction of campaign information to other modules if necessary
/// </summary>
public record CampaignDetailsQuery(Guid Id) : IRequest<CampaignDetails?>;