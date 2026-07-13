using BinnoMetric.Abstractions;
using BinnoMetric.DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionRecordsController : ControllerBase, ICanAdd<ProductionRecord>, ICanGet<ProductionRecord>, ICanUpdate<ProductionRecord>, ICanDelete<ProductionRecord>
    {
        [HttpPost("AddProductionRecord")]
        public Task<ProductionRecord> AddAsync(ProductionRecord value)
        {
            throw new NotImplementedException();
        }
        [HttpPost("AddProductionRecords")]
        public Task<ICollection<ProductionRecord>> AddRangeAsync(ICollection<ProductionRecord> values)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("DeleteProductionRecord")]
        public Task<bool> CanDeleteAsync(ProductionRecord value)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetProductionRecords")]
        public Task<ICollection<ProductionRecord>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetProductionRecord")]
        public Task<ProductionRecord> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateProductionRecord")]
        public Task<ProductionRecord> UpdateAsync(ProductionRecord value)
        {
            throw new NotImplementedException();
        }
    }
}
