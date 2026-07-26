namespace BinnoMetric.DTO;
public class TopEmployeesForCurrentProductDTO
{
    public string ProductName { get; set; }
    public int ProductId { get; set; }
    public List<EmployeeStatDTO> EmployeesStat {  get; set; }
}
