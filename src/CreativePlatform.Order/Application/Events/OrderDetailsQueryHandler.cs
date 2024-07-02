using CreativePlatform.Order.Application.Orders;
using CreativePlatform.Order.Contracts;
using MediatR;

namespace CreativePlatform.Order.Application.Events;

internal class OrderDetailsQueryHandler(Orders.OrderMapper mapper, IOrderService orderService)
    : IRequestHandler<OrderDetailsQuery, OrderDetails?>
{
    public async Task<OrderDetails?> Handle(OrderDetailsQuery request, CancellationToken cancellationToken)
    {
        OrderDto? order = await orderService.GetOrderByOrderNumberAsync(request.OrderNumber);
        if (order == null)
        {
            return null;
        }

        var result = mapper.ToOrderDetails(order);
        return result;
    }
}