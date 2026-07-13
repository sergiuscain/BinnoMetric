namespace BinnoMetric.DTO;
public class DowntimeTypeDTO
{
    public int Id { get; set; }
    public string Name { get; set; } // "Обед", "МУ", "ГУ", "ТО", и т.д.
    public bool IsPlanned { get; set; } // true - плановый, false - внеплановый
}
