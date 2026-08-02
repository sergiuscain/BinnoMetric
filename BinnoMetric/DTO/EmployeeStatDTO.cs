namespace BinnoMetric.DTO;
public class EmployeeStatDTO
{
    public string FullName { get; set; }
    public int ShiftsCount { get; set; }
    public int? TotalProductsCount { get; set; }
    public int? AverageProductsCount { get; set; }
}