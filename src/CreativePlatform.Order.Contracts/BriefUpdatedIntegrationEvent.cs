using CreativePlatform.SharedKernel;

namespace CreativePlatform.Order.Contracts;

public record BriefUpdatedIntegrationEvent(Guid Id, string BriefId, string AssetId, string OrderNumber, Guid CampaignId) : IIntegrationEvent;