using BinnoMetric.DataBase;
using BinnoMetric.DTO;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.Service;

public class ProductService
{
    private readonly BinnoDBContext _dbContext;
    public ProductService(BinnoDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    internal async Task<ProductDTO> AddAsync(ProductDTO values)
    {
        try
        {
            await _dbContext.Products.AddAsync(values.ToModel());
            await _dbContext.SaveChangesAsync();
            return values;
        }
        catch
        {
            return null;
        }
    }
    internal async Task<ICollection<ProductDTO>> AddAsync(ICollection<ProductDTO> values)
    {
        try
        {
            await _dbContext.Products.AddRangeAsync(values.Select(x => x.ToModel()));
            await _dbContext.SaveChangesAsync();
            return values;
        }
        catch
        {
            return null;
        }
    }

    internal async Task<bool> DeleteAsync(int id)
    {
        try
        {
             var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal async Task<ICollection<ProductDTO>> GetAllAsync()
    {
        try
        {
             var products = await _dbContext.Products.ToListAsync();
             var productsDto = products.Select(x => x.ToDTO()).ToList();
             return productsDto;
        }
        catch
        {
            return null;
        }
    }

    internal async Task<ProductDTO> GetAsync(int id)
    {
        try
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product.ToDTO();
        }
        catch
        {
            return null;
        }
    }

    internal async Task<ProductDTO> UpdateAsync(ProductDTO value)
    {
        try
        {
            _dbContext.Products.Update(value.ToModel());
            await _dbContext.SaveChangesAsync();
            return value;
        }
        catch
        {
            return null;
        }
    }
}