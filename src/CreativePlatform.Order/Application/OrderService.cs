using CreativePlatform.Order.Endpoints;
using CreativePlatform.Order.Infrastructure;

namespace CreativePlatform.Order.Application;

internal interface IOrderService
{
    Task<OrderDto> CreateOrderOfBriefsAsync(CreateOrderDto order);
    Task<OrderDto?> GetOrderByOrderNumberAsync(string orderNumber);
}

internal class OrderService(OrderMapper mapper, BriefMapper briefMapper, IOrderRepository repository, IBriefRepository briefRepository) : IOrderService
{
    public async Task<OrderDto> CreateOrderOfBriefsAsync(CreateOrderDto orderDto)
    {
        // TODO
        // Rather than two separate repository calls, consider using a transaction to ensure that either all data is created,
        // or an error is shown
        var order = mapper.ToOrder(orderDto);
        var createdOrder = await repository.CreateOrderAsync(order);

        var briefs = await briefRepository.AddBriefsAsync(orderDto.Briefs.Select(briefMapper.ToBrief), createdOrder.OrderId);

        var result = mapper.ToOrderDto(order);
        result.Briefs = briefs.Select(briefMapper.ToCampaignOrderBriefDto).ToList();
        return result;
    }

    public async Task<OrderDto?> GetOrderByOrderNumberAsync(string orderNumber)
    {
        var order = await repository.GetOrderByOrderNumberAsync(orderNumber);

        if (order is null)
        {
            return null;
        }

        var briefs = await briefRepository.GetBriefsByOrderIdAsync(order.OrderId);

        var result = mapper.ToOrderDto(order);
        result.Briefs = briefs.Select(briefMapper.ToCampaignOrderBriefDto).ToList();
        return result;
    }
}