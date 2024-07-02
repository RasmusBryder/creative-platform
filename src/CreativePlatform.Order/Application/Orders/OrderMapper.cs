using CreativePlatform.Order.Contracts;
using CreativePlatform.Order.Domain.Orders;
using CreativePlatform.Order.Endpoints.Orders;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Order.Application.Orders;

[Mapper]
internal partial class OrderMapper
{
    public partial CreateOrderDto ToCreateOrderDto(CreateOrderRequest request);

    public partial OrderDetails ToOrderDetails(OrderDto order);

    public partial OrderDto ToOrderDto(OrderResource order);

    public partial OrderResource ToOrder(CreateOrderDto orderDto);

    public partial OrderResponse ToOrderResponse(OrderDto order);
}