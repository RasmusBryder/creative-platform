using CreativePlatform.Campaign.Contracts;
using CreativePlatform.Campaign.Domain;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Campaign.Application;

[Mapper]
internal partial class CampaignMapper
{
    public partial CampaignDetails ToCampaignDetails(CampaignResource campaignResource);
    public partial CampaignDto ToCampaignDto(CampaignResource campaignResource);
}
