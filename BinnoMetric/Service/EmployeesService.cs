using BinnoMetric.DataBase;
using BinnoMetric.Models;

namespace BinnoMetric.Service;
public class EmployeesService 
{
    private readonly BinnoDBContext _context;
    public EmployeesService(BinnoDBContext dBContext)
    {
        _context = dBContext;
    }
    public async Task AddEmployee(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }
}