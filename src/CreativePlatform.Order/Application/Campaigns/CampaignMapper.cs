using CreativePlatform.Order.Contracts;
using CreativePlatform.Order.Domain.Campaigns;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Order.Application.Campaigns;

[Mapper]
internal partial class CampaignMapper
{
    public partial CampaignDetails ToCampaignDetails(CampaignResource campaignResource);
    public partial CampaignDto ToCampaignDto(CampaignResource campaignResource);
}