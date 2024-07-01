using CreativePlatform.SharedKernel;

namespace CreativePlatform.Order.Contracts;

public record OrderCreatedIntegrationEvent(Guid Id, string OrderNumber) : IIntegrationEvent;