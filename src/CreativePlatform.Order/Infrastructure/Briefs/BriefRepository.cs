using CreativePlatform.Order.Domain.Briefs;
using CreativePlatform.Order.Domain.Orders;

namespace CreativePlatform.Order.Infrastructure.Briefs;


internal interface IBriefRepository
{
    /// <summary>
    /// Bulk insert of briefs
    /// </summary>
    /// <param name="briefs"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    Task<BriefResource[]> AddBriefsAsync(IEnumerable<BriefResource> briefs, OrderResource order);

    Task<BriefResource?> GetBriefAsync(string briefId);

    Task<BriefResource[]> GetBriefsByOrderNumberAsync(string orderNumber);

    Task<BriefResource?> UpdateBriefAsync(UpdateBriefResource brief);
}

internal class BriefRepositoryStub : IBriefRepository
{
    public Task<BriefResource[]> AddBriefsAsync(IEnumerable<BriefResource> briefs, OrderResource order)
    {
        var campaignBriefs = briefs as BriefResource[] ?? briefs.ToArray();
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

    public Task<BriefResource?> GetBriefAsync(string briefId)
    {
        var brief = BriefFaker.Generate();
        brief.BriefId = briefId;
        return Task.FromResult(brief)!;
    }

    public Task<BriefResource[]> GetBriefsByOrderNumberAsync(string orderNumber)
    {
        var briefs = BriefFaker.Generate(10);
        foreach (var brief in briefs)
        {
            brief.OrderNumber = orderNumber;
            brief.AssetId = brief.BriefId.Replace("BRIEF", "ASSET");
        }

        return Task.FromResult(briefs.ToLookup(x => x.BriefId).Select(x => x.First()).ToArray());
    }

    public Task<BriefResource?> UpdateBriefAsync(UpdateBriefResource updateBrief)
    {
        var brief = BriefFaker.Generate();
        brief.BriefId = updateBrief.BriefId;
        if (updateBrief.AssetId is not null)
        {
            brief.AssetId = updateBrief.AssetId;
        }
        if (updateBrief.Name is not null)
        {
            brief.Name = updateBrief.Name;
        }
        if (updateBrief.Description is not null)
        {
            brief.Description = updateBrief.Description;
        }
        if (updateBrief.Comments is not null)
        {
            brief.Comments = updateBrief.Comments;
        }
        if (updateBrief.Status is not null)
        {
            brief.Status = updateBrief.Status;
        }
        return Task.FromResult(brief)!;
    }


    private static readonly BriefFaker BriefFaker = new();
}