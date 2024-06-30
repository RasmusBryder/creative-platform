using MediatR;

namespace CreativePlatform.Order.Contracts;

public class OrderDetails
{
    public string CampaignId { get; set; }
    public string OrderNumber { get; set; }
    public string[] BriefIds { get; set; }
}

public record OrderDetailsQuery(string OrderNumber) : IRequest<OrderDetails?>;