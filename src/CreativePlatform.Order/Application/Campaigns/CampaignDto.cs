namespace CreativePlatform.Order.Application.Campaigns;

public class CampaignDto(
    Guid id,
    string name,
    string distributionDate,
    string[] distributionChannels,
    string[] distributionMethods)
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public string DistributionDate { get; } = distributionDate;
    public string[] DistributionChannels { get; } = distributionChannels;
    public string[] DistributionMethods { get; } = distributionMethods;
}