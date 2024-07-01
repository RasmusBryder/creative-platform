using CreativePlatform.Campaign.Domain;

namespace CreativePlatform.Campaign.Infrastructure;

public interface ICampaignRepository
{
    Task<CampaignResource?> GetAsync(Guid id);
}

public class CampaignRepositoryStub : ICampaignRepository
{
    public Task<CampaignResource?> GetAsync(Guid id)
    {
        return Task.FromResult(new CampaignResource(id,
            "ToBeDefined",
            [
                "Websites", "Social Media", "Owned"
            ],
            ["ToBeDefined"]))!;
    }
}