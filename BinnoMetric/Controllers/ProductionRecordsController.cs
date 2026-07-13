using BinnoMetric.Abstractions;
using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionRecordsController : ControllerBase, ICanAdd<ProductionRecordDTO>, ICanGet<ProductionRecordDTO>, ICanUpdate<ProductionRecordDTO>, ICanDelete<ProductionRecordDTO>
    {
        [HttpPost("AddProductionRecord")]
        public Task<ProductionRecordDTO> AddAsync(ProductionRecordDTO value)
        {
            throw new NotImplementedException();
        }
        [HttpPost("AddProductionRecords")]
        public Task<ICollection<ProductionRecordDTO>> AddRangeAsync(ICollection<ProductionRecordDTO> values)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("DeleteProductionRecord")]
        public Task<bool> CanDeleteAsync(ProductionRecordDTO value)
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetProductionRecords")]
        public Task<ICollection<ProductionRecordDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("GetProductionRecord")]
        public Task<ProductionRecordDTO> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("UpdateProductionRecord")]
        public Task<ProductionRecordDTO> UpdateAsync(ProductionRecordDTO value)
        {
            throw new NotImplementedException();
        }
    }
}
