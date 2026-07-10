using BinnoMetric.Abstractions;
using BinnoMetric.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase, ICanAdd<Product>, ICanGet<Product>, ICanUpdate<Product>, ICanDelete<Product>
    {
        public Task<Product> AddAsync(Product value)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> AddRangeAsync(ICollection<Product> values)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CanDeleteAsync(Product value)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product value)
        {
            throw new NotImplementedException();
        }
    }
}
