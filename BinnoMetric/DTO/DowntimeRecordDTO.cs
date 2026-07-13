namespace BinnoMetric.DTO;
public class DowntimeRecordDTO
{
    public int Id { get; set; }
    public int ProductionRecordId { get; set; }
    public int DowntimeTypeId { get; set; }
    public int DurationMinutes { get; set; }
}
