using CreativePlatform.Order.Application;
using CreativePlatform.Order.Application.Briefs;
using FastEndpoints;
using BriefMapper = CreativePlatform.Order.Application.Briefs.BriefMapper;

namespace CreativePlatform.Order.Endpoints.Briefs;

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