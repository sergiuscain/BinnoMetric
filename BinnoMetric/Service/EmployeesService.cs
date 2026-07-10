using BinnoMetric.DataBase;
using BinnoMetric.Models;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.Service;
public class EmployeesService 
{
    private readonly BinnoDBContext _context;
    public EmployeesService(BinnoDBContext dBContext)
    {
        _context = dBContext;
    }
    public async Task<Employee> AddEmployee(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return await _context.Employees.FindAsync(employee);
    }
}