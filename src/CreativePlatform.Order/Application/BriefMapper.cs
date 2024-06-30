using CreativePlatform.Order.Contracts;
using CreativePlatform.Order.Endpoints;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Order.Application;

[Mapper]
internal partial class BriefMapper
{
    public partial CampaignBrief ToBrief(CreateOrderDto.CreateOrderBriefDto orderBriefDto);
    public partial CampaignBriefDto ToBriefDto(CampaignBrief brief);
    public partial OrderDto.CampaignOrderBriefDto ToCampaignOrderBriefDto(CampaignBrief brief);

    public partial CampaignBriefDetails ToBriefDetails(CampaignBriefDto brief);
    public partial BriefsResponse.BriefResponse ToBriefResponse(CampaignBriefDto brief);
}