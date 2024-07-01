namespace CreativePlatform.Order.Endpoints;

internal class BriefsResponse(BriefResponse[] briefs)
{
    public BriefResponse[] Briefs { get; } = briefs;
}