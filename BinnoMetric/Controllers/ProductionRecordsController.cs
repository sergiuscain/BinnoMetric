using BinnoMetric.Abstractions;
using BinnoMetric.DTO;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductionRecordsController : ControllerBase, ICanAdd<ProductionRecordDTO>, ICanGet<ProductionRecordDTO>, ICanUpdate<ProductionRecordDTO>, ICanDelete<int>
{
    private readonly ProductionRecordsService _productionRecordsService;
    public ProductionRecordsController(ProductionRecordsService productionRecordsService)
    {
        _productionRecordsService = productionRecordsService;
    }

    [HttpPost("AddProductionRecord")]
    public async Task<ProductionRecordDTO> AddAsync(ProductionRecordDTO value)
    {
        return await _productionRecordsService.AddAsync(value);
    }
    [HttpPost("AddProductionRecords")]
    public async Task<ICollection<ProductionRecordDTO>> AddRangeAsync(ICollection<ProductionRecordDTO> values)
    {
        return await _productionRecordsService.AddRangeAsync(values);
    }
    [HttpDelete("DeleteProductionRecord")]
    public async Task<bool> DeleteAsync(int id)
    {
        return await _productionRecordsService.DeleteAsync(id);
    }
    [HttpGet("GetProductionRecords")]
    public async Task<ICollection<ProductionRecordDTO>> GetAllAsync()
    {
        return await _productionRecordsService.GetAllAsync();
    }
    [HttpGet("GetProductionRecord")]
    public async Task<ProductionRecordDTO> GetAsync(int id)
    {
        return await _productionRecordsService.GetAsync(id);
    }
    [HttpPut("UpdateProductionRecord")]
    public async Task<ProductionRecordDTO> UpdateAsync(ProductionRecordDTO value)
    {
        return await _productionRecordsService.UpdateAsync(value);
    }
}
