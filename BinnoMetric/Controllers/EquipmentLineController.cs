using BinnoMetric.DataBase.Models;
using BinnoMetric.Service;
using Microsoft.AspNetCore.Mvc;

namespace BinnoMetric.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentLineController : Controller
{
    private readonly EquipmentLineService _equipmentLineService;
    public EquipmentLineController(EquipmentLineService equipmentLineService)
    {
        _equipmentLineService = equipmentLineService;
    }
    /// <summary>
    /// Получает все производственные линии
    /// </summary>
    /// <returns>Список линий или пустой лист</returns>
    [HttpGet("GetLines")]
    public async Task<ActionResult<List<EquipmentLine>>> GetLinesAsync()
    {
        return await _equipmentLineService.GetLinesAsync();
    }
    /// <summary>
    /// Получает производственную линию по её ID
    /// </summary>
    /// <param name="id">ID линии</param>
    /// <returns>Линия с указаным ID или null</returns>
    [HttpGet("GetLine")]
    public async Task<ActionResult<EquipmentLine>> GetLineAsync(int id)
    {
        var line = await _equipmentLineService.GetLineAsync(id);

        return line != null ? line : NotFound();
    }

}
