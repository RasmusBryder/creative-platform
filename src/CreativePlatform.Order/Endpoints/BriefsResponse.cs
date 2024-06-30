namespace CreativePlatform.Order.Endpoints;

internal class BriefsResponse
{
    public BriefsResponse(BriefResponse[] briefs, Dictionary<string, string> assetsByBriefId)
    {
        foreach (var asset in assetsByBriefId)
        {
            var brief = briefs.FirstOrDefault(x => x.BriefId == asset.Key);
            if (brief is not null)
            {
                brief.AssetId = asset.Value;
            }
        }
    }
    public class BriefResponse
    {
        public string BriefId { get; set; }
        public string AssetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
}