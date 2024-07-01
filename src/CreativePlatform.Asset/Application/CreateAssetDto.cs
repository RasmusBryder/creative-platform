namespace CreativePlatform.Asset.Application;

internal class CreateAssetDto(string name, string description, string briefId, string fileFormat, string fileSize, string userName)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public string BriefId { get; set; } = briefId;
    public string FileFormat { get; set; } = fileFormat;
    public string FileSize { get; set; } = fileSize;
    public string UserName { get; set; } = userName;
    public string? Comments { get; set; }
}