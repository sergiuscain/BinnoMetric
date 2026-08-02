namespace BinnoMetric.DataBase.Models;
public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public bool IsActive { get; set; } = true;
}