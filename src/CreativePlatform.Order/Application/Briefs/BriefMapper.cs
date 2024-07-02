using CreativePlatform.Order.Application.Orders;
using CreativePlatform.Order.Domain.Briefs;
using CreativePlatform.Order.Endpoints.Briefs;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Order.Application.Briefs;

[Mapper]
internal partial class BriefMapper
{
    public partial BriefResource ToBrief(CreateOrderDto.CreateOrderBriefDto orderBriefDto);
    public partial BriefDto ToBriefDto(BriefResource brief);
    public partial OrderDto.CampaignOrderBriefDto ToCampaignOrderBriefDto(BriefResource brief);
    public partial BriefResponse ToBriefResponse(BriefDto brief);
    public partial UpdateBriefDto ToUpdateBriefDto(UpdateBriefRequest request);
    public partial BriefResource ToBrief(UpdateBriefDto request);
    public partial UpdateBriefResource ToUpdateBriefResource(BriefResource brief);
    public partial UpdateBriefResource ToUpdateBriefResource(UpdateBriefDto brief);
}