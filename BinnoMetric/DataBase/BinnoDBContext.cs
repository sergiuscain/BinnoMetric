using BinnoMetric.Models;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.DataBase;
public class BinnoDBContext : DbContext
{
    public BinnoDBContext(DbContextOptions<BinnoDBContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Employee> Employees { get; set; }
}
