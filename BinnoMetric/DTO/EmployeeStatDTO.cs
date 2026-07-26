namespace BinnoMetric.DTO;
public class EmployeeStatDTO
{
    public string ShortName { get; set; }
    public int ShiftsCount { get; set; }
    public int? TotalProductsCount { get; set; }
    public int? AverageProductsCount { get; set; }
}