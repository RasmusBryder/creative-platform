using Bogus;
using CreativePlatform.Order.Domain;

namespace CreativePlatform.Order.Infrastructure;

internal interface IOrderRepository
{
    Task<OrderResource> CreateOrderAsync(OrderResource order);
    Task<OrderResource?> GetOrderByOrderNumberAsync(string orderNumber);
    Task<OrderResource[]> GetOrdersByCampaignIdAsync(Guid campaignId);
}

internal class OrderRepositoryStub : IOrderRepository
{
    public Task<OrderResource> CreateOrderAsync(OrderResource order)
    {
        order.OrderNumber = $"ORD{Faker.Random.Number(999999999)}";
        return Task.FromResult(order);
    }

    public Task<OrderResource?> GetOrderByOrderNumberAsync(string orderNumber)
    {
        var order = OrderFaker.Generate();
        order.OrderNumber = orderNumber;
        return Task.FromResult(order)!;
    }

    public Task<OrderResource[]> GetOrdersByCampaignIdAsync(Guid campaignId)
    {
        var order = OrderFaker.Generate();
        order.OrderNumber = $"ORD{Faker.Random.Number(999999999)}";
        order.CampaignId = campaignId;
        return Task.FromResult(new[] { order });
    }

    private static readonly Faker<OrderResource> OrderFaker = new Faker<OrderResource>()
        .RuleFor(x => x.CampaignId, _ => Guid.NewGuid())
        .RuleFor(x => x.RequesterName, x => x.Person.UserName);

    private static readonly Faker Faker = new();
}

