using MediatR;

namespace CreativePlatform.Asset.Contracts;

public record AssetDetailsByBriefId(
    AssetDetails[] Assets);

public record AssetDetails(string AssetId, string Name);

public record AssetDetailsByBriefIdQuery(string[] BriefIds) : IRequest<AssetDetailsByBriefId>;