namespace BinnoMetric.Models;
public class EquipmentLine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public bool IsActive { get; set; } = true;
}