namespace BinnoMetric.Models;
public class DowntimeType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; } // "Planned" или "Unplanned"
    public bool IsActive { get; set; } = true;
}