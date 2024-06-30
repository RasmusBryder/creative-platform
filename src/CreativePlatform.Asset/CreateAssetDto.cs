namespace CreativePlatform.Asset;

internal record CreateAssetDto
{
    public string BriefId { get; set; }
    public string FileFormat { get; set; }
    public string FileSize { get; set; }
    public string CreatedBy { get; set; }
    public string UserName { get; set; }
    public string Comments { get; set; }
}