using CreativePlatform.Order.Application;
using CreativePlatform.Order.Application.Briefs;
using FastEndpoints;
using BriefMapper = CreativePlatform.Order.Application.Briefs.BriefMapper;

namespace CreativePlatform.Order.Endpoints.Briefs;

public record UpdateBriefRequest(string BriefId, string? Status, string? Comments);

internal class UpdateBrief(BriefMapper mapper, IBriefService briefService)
    : Endpoint<UpdateBriefRequest, BriefResponse>
{
    public override void Configure()
    {
        Patch("/briefs/{BriefId}");
        AllowAnonymous(); // TODO: Add authentication
    }

    public override async Task HandleAsync(UpdateBriefRequest request, CancellationToken ct)
    {
        var brief = mapper.ToUpdateBriefDto(request);

        var updatedBrief = await briefService.UpdateBriefAsync(brief);

        if (updatedBrief is null)
        {
            ThrowError("Brief not found");
            return;
        }

        var result = mapper.ToBriefResponse(updatedBrief);

        await SendAsync(result, cancellation: ct);
    }
}