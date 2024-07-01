using CreativePlatform.Order.Application;
using FastEndpoints;

namespace CreativePlatform.Order.Endpoints;

public record GetByOrderNumberRequest(string OrderNumber);

internal class GetByOrderNumber(OrderMapper mapper, IOrderService orderService) : Endpoint<GetByOrderNumberRequest, OrderResponse>
{
    public override void Configure()
    {
        Get("/orders/{OrderNumber}");
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(GetByOrderNumberRequest req, CancellationToken ct)
    {
        OrderDto? order = await orderService.GetOrderByOrderNumberAsync(req.OrderNumber);

        if (order is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var result = mapper.ToOrderResponse(order);
        await SendAsync(result, cancellation: ct);
    }
}