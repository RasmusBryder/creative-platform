using CreativePlatform.Order.Domain;
using CreativePlatform.Order.Endpoints;
using CreativePlatform.Order.Infrastructure;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Order.Application;

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