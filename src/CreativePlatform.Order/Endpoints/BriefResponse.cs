namespace CreativePlatform.Order.Endpoints;

public class BriefResponse(
    string briefId,
    string name,
    string createdBy,
    DateTime createdDate,
    string status)
{
    public string BriefId { get; set; } = briefId;
    public string? AssetId { get; set; }
    public string Name { get; set; } = name;
    public string? Description { get; set; }
    public string CreatedBy { get; set; } = createdBy;
    public DateTime CreatedDate { get; set; } = createdDate;
    public string Status { get; set; } = status;
    public string? Comments { get; set; }
}