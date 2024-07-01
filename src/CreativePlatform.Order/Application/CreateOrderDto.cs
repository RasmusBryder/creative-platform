namespace CreativePlatform.Order.Application;

internal class CreateOrderDto(string requesterName, Guid campaignId, List<CreateOrderDto.CreateOrderBriefDto> briefs)
{
    public string RequesterName { get; set; } = requesterName;
    public Guid CampaignId { get; set; } = campaignId;
    public List<CreateOrderBriefDto> Briefs { get; set; } = briefs;

    internal class CreateOrderBriefDto(string name, string description, int quantity)
    {
        public string Name { get; } = name;
        public int Quantity { get; } = quantity;
        public string Description { get; } = description;
    }
}