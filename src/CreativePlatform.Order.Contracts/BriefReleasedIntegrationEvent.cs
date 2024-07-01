using CreativePlatform.SharedKernel;

namespace CreativePlatform.Order.Contracts;

public record BriefReleasedIntegrationEvent(Guid Id, string AssetId) : IIntegrationEvent;