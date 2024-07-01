namespace CreativePlatform.Asset.Domain;

internal class AssetResource(
    string briefId,
    string fileFormat,
    string fileSize,
    string userName)
{
    public string AssetId { get; set; } = string.Empty;
    public string BriefId { get; set; } = briefId;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string FileFormat { get; set; } = fileFormat;
    public string FileSize { get; set; } = fileSize;
    public string? Path { get; set; } // Could also be DAM reference
    public string VersionNumber { get; set; } = "1.0";
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
    public string UserName { get; set; } = userName;
    public string? Comments { get; set; }
    public string? Preview { get; set; }
    public string Status { get; set; } = string.Empty;
}