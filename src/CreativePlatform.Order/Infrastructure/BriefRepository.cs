namespace CreativePlatform.Order.Infrastructure;


internal interface IBriefRepository
{
    /// <summary>
    /// Bulk insert of briefs
    /// </summary>
    /// <param name="briefs"></param>
    /// <param name="orderId"></param>
    /// <returns></returns>
    Task<CampaignBrief[]> AddBriefsAsync(IEnumerable<CampaignBrief> briefs, Guid orderId);

    Task<CampaignBrief[]> GetBriefsByOrderIdAsync(Guid orderId);
}

internal class BriefRepositoryStub : IBriefRepository
{
    public Task<CampaignBrief[]> AddBriefsAsync(IEnumerable<CampaignBrief> briefs, Guid orderId)
    {
        var campaignBriefs = briefs as CampaignBrief[] ?? briefs.ToArray();
        var idSuffix = 0;
        foreach (var brief in campaignBriefs)
        {
            var id = $"BRIEF0{(++idSuffix).ToString().PadLeft(2, '0')}";
            brief.BriefId = id;
            brief.OrderId = orderId;
        }

        return Task.FromResult(campaignBriefs.ToArray());
    }

    public Task<CampaignBrief[]> GetBriefsByOrderIdAsync(Guid orderId)
    {
        var briefs = BriefFaker.Generate(10);
        foreach (var brief in briefs)
        {
            brief.OrderId = orderId;
        }

        return Task.FromResult(briefs.ToArray());
    }

    private static readonly CampaignBriefFaker BriefFaker = new();
}