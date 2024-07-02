using CreativePlatform.Order.Contracts;
using CreativePlatform.Order.Infrastructure.Briefs;
using CreativePlatform.Order.Infrastructure.Campaigns;
using CreativePlatform.Order.Infrastructure.Orders;
using CreativePlatform.SharedKernel;

namespace CreativePlatform.Order.Application.Orders;

internal interface IOrderService
{
    Task<OrderDto> CreateOrderOfBriefsAsync(CreateOrderDto order);
    Task<OrderDto?> GetOrderByOrderNumberAsync(string orderNumber);
}


internal class OrderService(OrderMapper mapper,
    Briefs.BriefMapper briefMapper,
    IOrderRepository repository,
    IBriefRepository briefRepository,
    ICampaignRepository campaignRepository,
    IEventBus eventBus) : IOrderService
{
    public async Task<OrderDto> CreateOrderOfBriefsAsync(CreateOrderDto orderDto)
    {
        // TODO:
        // Rather than two separate repository calls, consider using a transaction to ensure that either all data is created,
        // or an error is shown
        var order = mapper.ToOrder(orderDto);
        var createdOrder = await repository.CreateOrderAsync(order);

        var briefs = await briefRepository.AddBriefsAsync(orderDto.Briefs.Select(briefMapper.ToBrief), createdOrder);

        var campaignTask = campaignRepository.GetAsync(order.CampaignId);

        await eventBus.PublishAsync(new OrderCreatedIntegrationEvent(Guid.NewGuid(), order.OrderNumber));

        var result = mapper.ToOrderDto(order);

        var campaign = await campaignTask;

        result.Briefs = briefs.Select(briefMapper.ToCampaignOrderBriefDto).ToList();
        result.CampaignName = campaign?.Name;

        return result;
    }

    public async Task<OrderDto?> GetOrderByOrderNumberAsync(string orderNumber)
    {
        var order = await repository.GetOrderByOrderNumberAsync(orderNumber);

        if (order is null)
        {
            return null;
        }

        var campaignTask = campaignRepository.GetAsync(order.CampaignId);
        var briefs = await briefRepository.GetBriefsByOrderNumberAsync(orderNumber);

        var campaign = await campaignTask;

        var result = mapper.ToOrderDto(order);

        result.Briefs = briefs.Select(briefMapper.ToCampaignOrderBriefDto).ToList();
        result.CampaignName = campaign?.Name;
        return result;
    }
}