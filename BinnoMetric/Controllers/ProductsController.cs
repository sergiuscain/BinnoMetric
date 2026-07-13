using BinnoMetric.Abstractions;
using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase, ICanAdd<ProductDTO>, ICanGet<ProductDTO>, ICanUpdate<ProductDTO>, ICanDelete<ProductDTO>
    {
        [HttpPost("AddProduct")]
        public Task<ProductDTO> AddAsync(ProductDTO value)
        {
            throw new NotImplementedException();
        }
        [HttpPost("AddProducts")]
        public Task<ICollection<ProductDTO>> AddRangeAsync(ICollection<ProductDTO> values)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("DeleteProduct")]
        public Task<bool> CanDeleteAsync(ProductDTO value)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetProducts")]
        public Task<ICollection<ProductDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetProduct")]
        public Task<ProductDTO> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateProduct")]
        public Task<ProductDTO> UpdateAsync(ProductDTO value)
        {
            throw new NotImplementedException();
        }
    }
}
