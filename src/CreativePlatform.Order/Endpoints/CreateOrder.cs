using CreativePlatform.Order.Application;
using FastEndpoints;

namespace CreativePlatform.Order.Endpoints;

internal record CreateOrderRequest(
    Guid CampaignId,
    string RequesterName,
    List<CreateOrderRequest.CreateOrderBriefRequest> Briefs)
{
    internal record CreateOrderBriefRequest(string Name, string Description, int Quantity);
}

internal class CreateOrder(OrderMapper mapper, IOrderService orderService) : Endpoint<CreateOrderRequest, OrderResponse>
{
    public override void Configure()
    {
        Post("/orders");
        AllowAnonymous(); // TODO: Set up authentication
    }

    public override async Task HandleAsync(CreateOrderRequest req, CancellationToken ct)
    {
        var order = mapper.ToCreateOrderDto(req);

        OrderDto createdOrder = await orderService.CreateOrderOfBriefsAsync(order);

        var result = mapper.ToOrderResponse(createdOrder);

        await SendCreatedAtAsync<GetByOrderNumber>(new { result.OrderNumber }, result, cancellation: ct);
    }
}