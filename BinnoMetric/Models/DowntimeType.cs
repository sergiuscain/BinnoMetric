namespace BinnoMetric.Models;
public class DowntimeType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsPlanned { get; set; }
    public bool IsActive { get; set; } = true;
}