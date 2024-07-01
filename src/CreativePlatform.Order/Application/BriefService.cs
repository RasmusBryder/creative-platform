using CreativePlatform.Order.Contracts;
using CreativePlatform.Order.Domain;
using CreativePlatform.Order.Infrastructure;
using CreativePlatform.SharedKernel;

namespace CreativePlatform.Order.Application;

internal interface IBriefService
{
    Task<CampaignBriefDto[]> GetBriefsByOrderNumberAsync(string orderNumber);

    Task<CampaignBriefDto[]> GetBriefsByCampaignIdAsync(Guid campaignId);

    Task UpdateBriefWithAssetIdAsync(string briefId, string assetId, CancellationToken cancellationToken = default);
}

internal class BriefService(IEventBus eventBus, BriefMapper mapper, IBriefRepository repository, IOrderRepository orderRepository) : IBriefService
{
    public async Task<CampaignBriefDto[]> GetBriefsByOrderNumberAsync(string orderNumber)
    {
        var order = await orderRepository.GetOrderByOrderNumberAsync(orderNumber);
        if (order is null)
        {
            return [];
        }

        var briefs = await repository.GetBriefsByOrderNumberAsync(orderNumber);
        return briefs.Select(mapper.ToBriefDto).ToArray();
    }

    public async Task<CampaignBriefDto[]> GetBriefsByCampaignIdAsync(Guid campaignId)
    {
        var orders = await orderRepository.GetOrdersByCampaignIdAsync(campaignId);
        var briefs = new List<CampaignBrief>();
        foreach (var order in orders)
        {
            var briefsOfOrder = await repository.GetBriefsByOrderNumberAsync(order.OrderNumber);
            briefs.AddRange(briefsOfOrder);
        }

        return briefs.Select(mapper.ToBriefDto).ToArray();
    }

    public async Task UpdateBriefWithAssetIdAsync(string briefId, string assetId, CancellationToken cancellationToken = default)
    {
        var brief = await repository.GetBriefAsync(briefId);

        if (brief is null)
        {
            return;
        }
        brief.AssetId = assetId;

        await repository.UpdateBriefAsync(brief);

        await eventBus.PublishAsync(
            new BriefUpdatedIntegrationEvent(Guid.NewGuid(), briefId, assetId, 
                brief.OrderNumber, brief.CampaignId),
            cancellationToken);
    }
}