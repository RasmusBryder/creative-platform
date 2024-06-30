using Bogus;

namespace CreativePlatform.Order.Infrastructure;

internal interface IOrderRepository
{
    Task<Order> CreateOrderAsync(Order order);
    Task<Order?> GetOrderByOrderNumberAsync(string orderNumber);
    Task<Order[]> GetOrdersByCampaignIdAsync(string campaignId);
}

internal class OrderRepositoryStub : IOrderRepository
{
    public Task<Order> CreateOrderAsync(Order order)
    {
        order.OrderNumber = $"ORD{Faker.Random.Number(999999999)}";
        return Task.FromResult(order);
    }

    public Task<Order?> GetOrderByOrderNumberAsync(string orderNumber)
    {
        var order = OrderFaker.Generate();
        order.OrderNumber = orderNumber;
        return Task.FromResult(order)!;
    }

    public Task<Order[]> GetOrdersByCampaignIdAsync(string campaignId)
    {
        var order = OrderFaker.Generate();
        order.OrderNumber = $"ORD{Faker.Random.Number(999999999)}";
        order.CampaignId = campaignId;
        return Task.FromResult(new[] { order });
    }

    private static readonly Faker<Order> OrderFaker = new Faker<Order>()
        .RuleFor(x => x.CampaignId, x => $"CAMPAIGN0{x.Random.Number(0, 99).ToString().PadLeft(2, '0')}")
        .RuleFor(x => x.RequesterName, x => x.Person.UserName);

    private static readonly Faker Faker = new();
}

