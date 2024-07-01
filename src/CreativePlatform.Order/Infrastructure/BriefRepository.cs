using CreativePlatform.Order.Domain;

namespace CreativePlatform.Order.Infrastructure;


internal interface IBriefRepository
{
    /// <summary>
    /// Bulk insert of briefs
    /// </summary>
    /// <param name="briefs"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<CampaignBrief[]> AddBriefsAsync(IEnumerable<CampaignBrief> briefs, OrderResource order);

    Task<CampaignBrief?> GetBriefAsync(string briefId);

    Task<CampaignBrief[]> GetBriefsByOrderNumberAsync(string orderNumber);
    Task UpdateBriefAsync(CampaignBrief brief);
}

internal class BriefRepositoryStub : IBriefRepository
{
    public Task<CampaignBrief[]> AddBriefsAsync(IEnumerable<CampaignBrief> briefs, OrderResource order)
    {
        var campaignBriefs = briefs as CampaignBrief[] ?? briefs.ToArray();
        var idSuffix = 0;
        foreach (var brief in campaignBriefs)
        {
            var id = $"BRIEF0{(++idSuffix).ToString().PadLeft(2, '0')}";
            brief.BriefId = id;
            brief.OrderNumber = order.OrderNumber;
            brief.CampaignId = order.CampaignId;
        }

        return Task.FromResult(campaignBriefs.ToArray());
    }

    public Task<CampaignBrief?> GetBriefAsync(string briefId)
    {
        var brief = BriefFaker.Generate();
        brief.BriefId = briefId;
        return Task.FromResult(brief)!;
    }

    public Task<CampaignBrief[]> GetBriefsByOrderNumberAsync(string orderNumber)
    {
        var briefs = BriefFaker.Generate(10);
        foreach (var brief in briefs)
        {
            brief.OrderNumber = orderNumber;
        }

        return Task.FromResult(briefs.ToArray());
    }

    public Task UpdateBriefAsync(CampaignBrief brief)
    {
        return Task.CompletedTask;
    }

    private static readonly CampaignBriefFaker BriefFaker = new();
}