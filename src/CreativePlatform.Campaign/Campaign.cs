namespace CreativePlatform.Campaign;

public class Campaign(
    string id,
    string distributionDate,
    string[] distributionChannels,
    string[] distributionMethods)
{
    public string Id { get; } = id;
    public string DistributionDate { get; } = distributionDate;
    public string[] DistributionChannels { get; } = distributionChannels;
    public string[] DistributionMethods { get; } = distributionMethods;
}