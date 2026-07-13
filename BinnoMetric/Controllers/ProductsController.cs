using BinnoMetric.Abstractions;
using BinnoMetric.DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase, ICanAdd<Product>, ICanGet<Product>, ICanUpdate<Product>, ICanDelete<Product>
    {
        [HttpPost("AddProduct")]
        public Task<Product> AddAsync(Product value)
        {
            throw new NotImplementedException();
        }
        [HttpPost("AddProducts")]
        public Task<ICollection<Product>> AddRangeAsync(ICollection<Product> values)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("DeleteProduct")]
        public Task<bool> CanDeleteAsync(Product value)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetProducts")]
        public Task<ICollection<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetProduct")]
        public Task<Product> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateProduct")]
        public Task<Product> UpdateAsync(Product value)
        {
            throw new NotImplementedException();
        }
    }
}
