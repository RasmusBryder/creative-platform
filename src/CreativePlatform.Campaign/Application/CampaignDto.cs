namespace CreativePlatform.Campaign.Application;

public class CampaignDto(
    Guid id,
    string distributionDate,
    string[] distributionChannels,
    string[] distributionMethods)
{
    public Guid Id { get; } = id;
    public string DistributionDate { get; } = distributionDate;
    public string[] DistributionChannels { get; } = distributionChannels;
    public string[] DistributionMethods { get; } = distributionMethods;
}