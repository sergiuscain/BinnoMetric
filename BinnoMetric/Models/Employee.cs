namespace BinnoMetric.Models;
public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public bool IsActive { get; set; } = true;
}