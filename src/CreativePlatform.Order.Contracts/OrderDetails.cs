using MediatR;

namespace CreativePlatform.Order.Contracts;

public class OrderDetails
{
    public Guid CampaignId { get; set; }
    public string OrderNumber { get; set; }
}

/// <summary>
/// For extraction of order information to other modules if necessary
/// </summary>
/// <param name="OrderNumber"></param>
public record OrderDetailsQuery(string OrderNumber) : IRequest<OrderDetails?>;