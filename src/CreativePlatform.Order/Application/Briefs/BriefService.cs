using CreativePlatform.Order.Contracts;
using CreativePlatform.Order.Domain.Briefs;
using CreativePlatform.Order.Infrastructure.Briefs;
using CreativePlatform.Order.Infrastructure.Orders;
using CreativePlatform.SharedKernel;

namespace CreativePlatform.Order.Application.Briefs;

internal interface IBriefService
{
    Task<BriefDto[]> GetBriefsByOrderNumberAsync(string orderNumber);

    Task<BriefDto[]> GetBriefsByCampaignIdAsync(Guid campaignId);

    Task UpdateBriefWithAssetIdAsync(string briefId, string assetId, CancellationToken cancellationToken = default);

    Task<BriefDto?> UpdateBriefAsync(UpdateBriefDto brief);
}

internal class BriefService(IEventBus eventBus, BriefMapper mapper, IBriefRepository repository, IOrderRepository orderRepository) : IBriefService
{
    public async Task<BriefDto[]> GetBriefsByOrderNumberAsync(string orderNumber)
    {
        var order = await orderRepository.GetOrderByOrderNumberAsync(orderNumber);
        if (order is null)
        {
            return [];
        }

        var briefs = await repository.GetBriefsByOrderNumberAsync(orderNumber);
        return briefs.Select(mapper.ToBriefDto).ToArray();
    }

    public async Task<BriefDto[]> GetBriefsByCampaignIdAsync(Guid campaignId)
    {
        var orders = await orderRepository.GetOrdersByCampaignIdAsync(campaignId);
        var briefs = new List<BriefResource>();
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

        await repository.UpdateBriefAsync(mapper.ToUpdateBriefResource(brief));

        await eventBus.PublishAsync(
            new BriefUpdatedIntegrationEvent(Guid.NewGuid(), briefId, assetId, 
                brief.OrderNumber, brief.CampaignId),
            cancellationToken);
    }

    public async Task<BriefDto?> UpdateBriefAsync(UpdateBriefDto briefRequest)
    {
        var updatedBrief = await repository.UpdateBriefAsync(mapper.ToUpdateBriefResource(briefRequest));

        if (updatedBrief is null)
        {
            return null;
        }

        if (updatedBrief is { Status: BriefStatus.Released, AssetId: not null })
        {
            await eventBus.PublishAsync(new BriefReleasedIntegrationEvent(Guid.NewGuid(), updatedBrief.AssetId));
        }

        return mapper.ToBriefDto(updatedBrief);
    }
}