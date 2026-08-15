using BinnoMetric.DataBase;
using BinnoMetric.DTO;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.Service;
public class EmployeesService
{
    private readonly BinnoDBContext _context;
    public EmployeesService(BinnoDBContext dBContext)
    {
        _context = dBContext;
    }
    public async Task<EmployeeDTO> AddAsync(EmployeeDTO employeeDTO)
    {
        try
        {
            await _context.Employees.AddAsync(employeeDTO.ToModel());
            await _context.SaveChangesAsync();
            return employeeDTO;
        }
        catch
        {
            return null;
        }
    }

    internal async Task<ICollection<EmployeeDTO>> AddRangeAsync(ICollection<EmployeeDTO> values)
    {
        await _context.Employees.AddRangeAsync(values.Select(x => x.ToModel()));
        await _context.SaveChangesAsync();
        return values;
    }

    internal async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal async Task<ICollection<EmployeeDTO>> GetAllAsync()
    {
        try
        {
            var employees = await _context.Employees.ToListAsync();
            return employees.Select(x => x.ToDTO()).ToList();
        }
        catch
        {
            return null;
        }
    }

    internal async Task<EmployeeDTO> GetAsync(int id)
    {
        try
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return employee.ToDTO();
        }
        catch
        {
            return null;
        }
    }

    // Потом разберусь, как правильно обновлять сотрудника. Там надо с парсингом в DTO и обратно разобраться.
    ////internal async Task<EmployeeDTO> UpdateAsync(EmployeeDTO value)
    ////{
    ////    try
    ////    {
    ////        _context.Employees.Update(value.ToModel());
    ////        await _context.SaveChangesAsync();
    ////        return value;
    ////    }
    ////    catch
    ////    {
    ////        return null;
    ////    }
    ////}
}