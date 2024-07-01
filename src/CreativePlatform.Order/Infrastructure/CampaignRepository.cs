using CreativePlatform.Order.Domain;

namespace CreativePlatform.Order.Infrastructure;

public interface ICampaignRepository
{
    Task<CampaignResource?> GetAsync(Guid id);
}

public class CampaignRepositoryStub : ICampaignRepository
{
    public Task<CampaignResource?> GetAsync(Guid id)
    {
        return Task.FromResult(new CampaignResource(id,
            "Star Wars Anniversary",
            "ToBeDefined",
            [
                "Websites", "Social Media", "Owned"
            ],
            ["ToBeDefined"]))!;
    }
}