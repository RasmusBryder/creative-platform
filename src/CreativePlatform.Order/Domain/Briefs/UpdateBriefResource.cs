namespace CreativePlatform.Order.Domain.Briefs;

internal class UpdateBriefResource(string briefId)
{
    public string BriefId { get; init; } = briefId;
    public string? AssetId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? Status { get; init; }
    public string? Comments { get; init; }
}