using CreativePlatform.Order.Application;
using FastEndpoints;

namespace CreativePlatform.Order.Endpoints;

public record GetBriefsByOrderNumberRequest(string OrderNumber);

internal class GetBriefsByOrderNumber(BriefMapper mapper, IBriefService briefService)
    : Endpoint<GetBriefsByOrderNumberRequest, BriefsResponse>
{
    public override void Configure()
    {
        Get("/orders/{OrderNumber}/briefs");
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(GetBriefsByOrderNumberRequest req, CancellationToken ct)
    {
        var briefs = await briefService.GetBriefsByOrderNumberAsync(req.OrderNumber);

        var results = briefs.Select(mapper.ToBriefResponse).ToArray();

        var response = new BriefsResponse(results);

        await SendAsync(response, cancellation: ct);
    }
}