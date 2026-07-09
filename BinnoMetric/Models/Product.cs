namespace BinnoMetric.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Dosage { get; set; }
    public string Form { get; set; }
    public int? PackSize { get; set; }
    public bool IsActive { get; set; } = true;
}
