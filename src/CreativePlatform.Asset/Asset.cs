namespace CreativePlatform.Asset;

/// <summary>
/// Constructors removed due to Bogus
/// </summary>
internal class Asset
{
    public string AssetId { get; set; }
    public string BriefId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FileFormat { get; set; }
    public string FileSize { get; set; }
    public string Path { get; set; } // Could also be DAM reference
    public string CreatedBy { get; set; }
    public string VersionNumber { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public string UserName { get; set; }
    public string Comments { get; set; }
    public string Preview { get; set; }
    public string Status { get; set; }
}