using CreativePlatform.Order.Infrastructure;

namespace CreativePlatform.Order.Application;

internal interface IBriefService
{
    Task<CampaignBriefDto[]> GetBriefsByOrderNumberAsync(string orderNumber);

    Task<CampaignBriefDto[]> GetBriefsByCampaignIdAsync(string campaignId);
}

internal class BriefService(BriefMapper mapper, IBriefRepository repository, IOrderRepository orderRepository) : IBriefService
{
    public async Task<CampaignBriefDto[]> GetBriefsByOrderNumberAsync(string orderNumber)
    {
        var order = await orderRepository.GetOrderByOrderNumberAsync(orderNumber);
        if (order is null)
        {
            return [];
        }

        var briefs = await repository.GetBriefsByOrderIdAsync(order.OrderId);
        return briefs.Select(mapper.ToBriefDto).ToArray();
    }

    public async Task<CampaignBriefDto[]> GetBriefsByCampaignIdAsync(string campaignId)
    {
        var orders = await orderRepository.GetOrdersByCampaignIdAsync(campaignId);
        var briefs = new List<CampaignBrief>();
        foreach (var order in orders)
        {
            var briefsOfOrder = await repository.GetBriefsByOrderIdAsync(order.OrderId);
            briefs.AddRange(briefsOfOrder);
        }

        return briefs.Select(mapper.ToBriefDto).ToArray();
    }
}