namespace CreativePlatform.Order.Endpoints.Briefs;

internal class BriefsResponse(BriefResponse[] briefs)
{
    public BriefResponse[] Briefs { get; } = briefs;
}