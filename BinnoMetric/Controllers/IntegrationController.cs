using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IntegrationController : ControllerBase
{
    private readonly IntegrationService _integrationService;

    public IntegrationController(IntegrationService integrationService)
    {
        _integrationService = integrationService;
    }

    [HttpPost("import-employees")]
    public async Task<IActionResult> ImportEmployees([FromBody] ImportRequest request)
    {
        if (string.IsNullOrEmpty(request.FilePath))
            return BadRequest("Путь к файлу не указан");

        if (!System.IO.File.Exists(request.FilePath))
            return NotFound($"Файл {request.FilePath} не найден");

        var result = await _integrationService.ImportEmployeesAsync(request.FilePath);
        return Ok(result);
    }

    [HttpPost("import-products")]
    public async Task<IActionResult> ImportProducts([FromBody] ImportRequest request)
    {
        if (string.IsNullOrEmpty(request.FilePath))
            return BadRequest("Путь к файлу не указан");

        if (!System.IO.File.Exists(request.FilePath))
            return NotFound($"Файл {request.FilePath} не найден");

        var result = await _integrationService.ImportProductsAsync(request.FilePath);
        return Ok(result);
    }

    [HttpPost("import-lines")]
    public async Task<IActionResult> ImportEquipmentLines([FromBody] ImportRequest request)
    {
        if (string.IsNullOrEmpty(request.FilePath))
            return BadRequest("Путь к файлу не указан");

        if (!System.IO.File.Exists(request.FilePath))
            return NotFound($"Файл {request.FilePath} не найден");

        var result = await _integrationService.ImportEquipmentLinesAsync(request.FilePath);
        return Ok(result);
    }

    [HttpPost("import-records")]
    public async Task<IActionResult> ImportProductionRecords([FromBody] ImportRequest request)
    {
        if (string.IsNullOrEmpty(request.FilePath))
            return BadRequest("Путь к файлу не указан");

        if (!System.IO.File.Exists(request.FilePath))
            return NotFound($"Файл {request.FilePath} не найден");

        var result = await _integrationService.ImportProductionRecordsAsync(request.FilePath);
        return Ok(result);
    }
}

public class ImportRequest
{
    public string FilePath { get; set; }
}