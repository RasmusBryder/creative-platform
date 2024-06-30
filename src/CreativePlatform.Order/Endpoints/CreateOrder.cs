using CreativePlatform.Order.Application;
using FastEndpoints;

namespace CreativePlatform.Order.Endpoints;

internal record CreateOrderRequest(Guid CampaignId, string RequesterName, List<CreateOrderRequest.CreateOrderBriefRequest> Briefs)
{
    internal record CreateOrderBriefRequest(string Name, string Description, int Quantity);

}

internal class CreateOrder(IOrderService orderService) : Endpoint<CreateOrderRequest, OrderResponse>
{
    public override void Configure()
    {
        Post("/campaigns/orders");
        AllowAnonymous(); // TODO: Set up authentication
    }

    public override async Task HandleAsync(CreateOrderRequest req, CancellationToken ct)
    {
        var mapper = new Application.OrderMapper();
        CreateOrderDto order = mapper.ToCreateOrderDto(req);

        OrderDto createdOrder = await orderService.CreateOrderOfBriefsAsync(order);
        var result = mapper.ToOrderResponse(createdOrder);
        // TODO: Provide campaign metadata
        result.CampaignName = "Star Wars Anniversary";

        await SendCreatedAtAsync<GetByOrderNumber>(new { result.OrderNumber }, result, cancellation: ct);
    }
}