namespace CreativePlatform.Order.Endpoints;

internal record CreateOrderDto
{
    public string RequesterName { get; set; }
    public Guid CampaignId { get; set; }
    public List<CreateOrderBriefDto> Briefs { get; set; }

    internal record CreateOrderBriefDto(string Name, string Description, int Quantity);
}