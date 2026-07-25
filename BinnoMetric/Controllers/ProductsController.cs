using BinnoMetric.Abstractions;
using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase, ICanAdd<ProductDTO>, ICanGet<ProductDTO>, ICanUpdate<ProductDTO>, ICanDelete<ProductDTO>
    {
        private ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("AddProduct")]
        public async Task<ProductDTO> AddAsync(ProductDTO value)
        {
            return await _productService.AddAsync(value);
        }
        [HttpPost("AddProducts")]
        public async Task<ICollection<ProductDTO>> AddRangeAsync(ICollection<ProductDTO> values)
        {
            return await _productService.AddAsync(values);
        }
        [HttpDelete("DeleteProduct")]
        public async Task<bool> DeleteAsync(ProductDTO value)
        {
            return await _productService.DeleteAsync(value);
        }
        [HttpGet("GetProducts")]
        public async Task<ICollection<ProductDTO>> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }
        [HttpGet("GetProduct")]
        public async Task<ProductDTO> GetAsync(int id)
        {
            return await _productService.GetAsync(id);
        }
        [HttpPut("UpdateProduct")]
        public async Task<ProductDTO> UpdateAsync(ProductDTO value)
        {
            return await _productService.UpdateAsync(value);
        }
    }
}
