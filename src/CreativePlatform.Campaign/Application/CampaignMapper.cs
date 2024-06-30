using CreativePlatform.Campaign.Contracts;
using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Campaign.Application;

[Mapper]
internal partial class CampaignMapper
{
    public partial CampaignDetails ToCampaignDetails(Campaign campaign);
}
