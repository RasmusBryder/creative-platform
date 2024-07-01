namespace CreativePlatform.Asset.Application;

/// <summary>
/// Asset, made as a result of campaign briefs, containing state of approval.
/// Assets are uploaded by creatives and stored in DAM.
/// </summary>
public class AssetDto(
    string assetId,
    string fileFormat,
    string fileSize,
    DateTimeOffset timestamp,
    string userName)
{
    public string AssetId { get; set; } = assetId;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string FileFormat { get; set; } = fileFormat;
    public string FileSize { get; set; } = fileSize;
    public string? Path { get; set; } // Could also be DAM reference
    public string? CreatedBy { get; set; }
    public string? VersionNumber { get; set; }
    public DateTimeOffset Timestamp { get; set; } = timestamp;
    public string UserName { get; set; } = userName;
    public string? Comments { get; set; }
    public string? Preview { get; set; } // Could also be DAM reference
    public string? Status { get; set; }
}