namespace CreativePlatform.Campaign.Infrastructure;

public interface ICampaignRepository
{
    Task<Campaign?> GetAsync(string id);
}

public class CampaignRepositoryStub : ICampaignRepository
{
    public Task<Campaign?> GetAsync(string id)
    {
        return Task.FromResult(new Campaign(id,
            "ToBeDefined",
            [
                "Websites", "Social Media", "Owned"
            ],
            ["ToBeDefined"]))!;
    }
}