using CreativePlatform.Content.Application;
using FastEndpoints;

namespace CreativePlatform.Content.Endpoints;

public record GetByOrderNumberRequest(string OrderNumber);

internal class GetByOrderNumber(IContentService contentService)
    : Endpoint<GetByOrderNumberRequest, CampaignContentDto>
{
    public override void Configure()
    {
        Get("/orders/{OrderNumber}/content"); // Should probably depend on campaign ID
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(GetByOrderNumberRequest req, CancellationToken ct)
    {
        ContentDto[] content = await contentService.GetDownloadableContentAsync(req.OrderNumber);

        var result = new CampaignContentDto(content);

        await SendAsync(result, cancellation: ct);
    }
}