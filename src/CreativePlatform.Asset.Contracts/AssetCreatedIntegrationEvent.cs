using CreativePlatform.SharedKernel;

namespace CreativePlatform.Asset.Contracts;

public record AssetCreatedIntegrationEvent(Guid Id, string AssetId, string? BriefId, string? AssetPath) : IIntegrationEvent;
