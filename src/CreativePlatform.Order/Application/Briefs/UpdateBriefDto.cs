namespace CreativePlatform.Order.Application.Briefs;

public class UpdateBriefDto(string briefId)
{
    public string BriefId { get; init; } = briefId;
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? Status { get; init; }
    public string? Comments { get; init; }
}