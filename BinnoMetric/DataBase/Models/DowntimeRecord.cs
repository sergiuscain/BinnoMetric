namespace BinnoMetric.DataBase.Models;
public class DowntimeRecord
{
    public int Id { get; set; }
    public int ProductionRecordId { get; set; }
    public int DowntimeTypeId { get; set; }
    public int DurationMinutes { get; set; } // Длительность простоя в минутах

    // Навигационные свойства
    public ProductionRecord ProductionRecord { get; set; }
    public DowntimeType DowntimeType { get; set; }
}
