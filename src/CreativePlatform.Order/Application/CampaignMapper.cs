using CreativePlatform.Order.Contracts;
using CreativePlatform.Order.Domain;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Order.Application;

[Mapper]
internal partial class CampaignMapper
{
    public partial CampaignDetails ToCampaignDetails(CampaignResource campaignResource);
    public partial CampaignDto ToCampaignDto(CampaignResource campaignResource);
}