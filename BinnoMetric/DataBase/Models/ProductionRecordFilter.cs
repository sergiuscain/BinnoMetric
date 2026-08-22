namespace BinnoMetric.DataBase.Models;

public class ProductionRecordFilter
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public int? EmployeeId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int? ProductId { get; set; }
    public int? EquipmentLineId { get; set; }
    public string? SeriesNumber { get; set; }
    public int? ActualQuantity { get; set; }
    public string? Comments { get; set; }
}
