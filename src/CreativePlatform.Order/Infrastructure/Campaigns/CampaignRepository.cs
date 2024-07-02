using Bogus;
using CreativePlatform.Order.Domain.Campaigns;

namespace CreativePlatform.Order.Infrastructure.Campaigns;

public interface ICampaignRepository
{
    Task<CampaignResource?> GetAsync(Guid id);
}

public class CampaignRepositoryStub : ICampaignRepository
{
    public Task<CampaignResource?> GetAsync(Guid id)
    {

        return Task.FromResult(new CampaignResource(id,
            Faker.Company.CatchPhrase(),
            "ToBeDefined",
            [
                "Websites", "Social Media", "Owned"
            ],
            ["ToBeDefined"]))!;
    }

    private static readonly Faker Faker = new();
}