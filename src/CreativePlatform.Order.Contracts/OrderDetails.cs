using MediatR;

namespace CreativePlatform.Order.Contracts;

public class OrderDetails(Guid campaignId, string orderNumber)
{
    public Guid CampaignId { get; set; } = campaignId;
    public string OrderNumber { get; set; } = orderNumber;
}

/// <summary>
///     For extraction of order information to other modules if necessary
/// </summary>
/// <param name="OrderNumber"></param>
public record OrderDetailsQuery(string OrderNumber) : IRequest<OrderDetails?>;