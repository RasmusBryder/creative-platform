using Riok.Mapperly.Abstractions;

namespace CreativePlatform.Content.Application;

[Mapper]
internal partial class ContentMapper
{
    public partial ContentDto ToContentDto(Content content);
}
