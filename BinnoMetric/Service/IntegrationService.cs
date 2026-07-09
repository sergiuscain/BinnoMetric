using BinnoMetric.DataBase;
using BinnoMetric.Models;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BinnoMetric.Service;

public class ImportResult
{
    public int TotalRows { get; set; }
    public int InsertedRows { get; set; }
    public int Errors { get; set; }
    public int SkippedRows { get; set; }
    public string Message { get; set; }
}

public class IntegrationService
{
    private readonly BinnoDBContext _context;

    public IntegrationService(BinnoDBContext context)
    {
        _context = context;
    }

    // === ШАГ 1: ИМПОРТ СОТРУДНИКОВ ===
    public async Task<ImportResult> ImportEmployeesAsync(string filePath)
    {
        var employees = new HashSet<string>();
        var result = new ImportResult();

        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheet(1);
        var rows = worksheet.RangeUsed().RowsUsed();

        foreach (var row in rows.Skip(1))
        {
            try
            {
                var senior = row.Cell(2).GetString()?.Trim();
                if (!string.IsNullOrEmpty(senior)) employees.Add(senior);

                var opD = row.Cell(3).GetString()?.Trim();
                if (!string.IsNullOrEmpty(opD)) employees.Add(opD);

                var opNKL = row.Cell(4).GetString()?.Trim();
                if (!string.IsNullOrEmpty(opNKL)) employees.Add(opNKL);

                var packer = row.Cell(5).GetString()?.Trim();
                if (!string.IsNullOrEmpty(packer)) employees.Add(packer);

                result.TotalRows++;
            }
            catch (Exception ex)
            {
                result.Errors++;
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        var existingEmployees = await _context.Employees
            .Select(e => e.FullName)
            .ToHashSetAsync();

        var newEmployees = employees
            .Where(e => !existingEmployees.Contains(e))
            .Select(name => new Employee
            {
                FullName = name,
                ShortName = ExtractEmployeeShortName(name)
            })
            .ToList();

        await _context.Employees.AddRangeAsync(newEmployees);
        await _context.SaveChangesAsync();

        result.InsertedRows = newEmployees.Count;
        result.Message = $"Импортировано сотрудников: {newEmployees.Count}";

        return result;
    }

    // === ШАГ 2: ИМПОРТ ПРОДУКТОВ ===
    public async Task<ImportResult> ImportProductsAsync(string filePath)
    {
        var products = new HashSet<string>();
        var result = new ImportResult();

        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheet(1);
        var rows = worksheet.RangeUsed().RowsUsed();

        foreach (var row in rows.Skip(1))
        {
            try
            {
                var productName = row.Cell(7).GetString()?.Trim();
                if (!string.IsNullOrEmpty(productName))
                    products.Add(productName);

                result.TotalRows++;
            }
            catch (Exception ex)
            {
                result.Errors++;
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        var existingProducts = await _context.Products
            .Select(p => p.Name)
            .ToHashSetAsync();

        var newProducts = products
            .Where(p => !existingProducts.Contains(p))
            .Select(name => new Product
            {
                Name = name,
                ShortName = ExtractShortName(name),
                Dosage = ExtractDosage(name),
                Form = ExtractForm(name),
                PackSize = ExtractPackSize(name)
            })
            .ToList();

        await _context.Products.AddRangeAsync(newProducts);
        await _context.SaveChangesAsync();

        result.InsertedRows = newProducts.Count;
        result.Message = $"Импортировано продуктов: {newProducts.Count}";

        return result;
    }

    // === ШАГ 3: ИМПОРТ ЛИНИЙ ОБОРУДОВАНИЯ ===
    public async Task<ImportResult> ImportEquipmentLinesAsync(string filePath)
    {
        var lines = new HashSet<string>();
        var result = new ImportResult();

        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheet(1);
        var rows = worksheet.RangeUsed().RowsUsed();

        foreach (var row in rows.Skip(1))
        {
            try
            {
                var lineName = row.Cell(8).GetString()?.Trim();
                if (!string.IsNullOrEmpty(lineName))
                    lines.Add(lineName);

                result.TotalRows++;
            }
            catch (Exception ex)
            {
                result.Errors++;
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        var existingLines = await _context.EquipmentLines
            .Select(l => l.Name)
            .ToHashSetAsync();

        var newLines = lines
            .Where(l => !existingLines.Contains(l))
            .Select(name => new EquipmentLine
            {
                Name = name,
                Code = ExtractLineCode(name)
            })
            .ToList();

        await _context.EquipmentLines.AddRangeAsync(newLines);
        await _context.SaveChangesAsync();

        result.InsertedRows = newLines.Count;
        result.Message = $"Импортировано линий: {newLines.Count}";

        return result;
    }

    // === ШАГ 4: ИМПОРТ ПРОИЗВОДСТВЕННЫХ ЗАПИСЕЙ ===
    public async Task<ImportResult> ImportProductionRecordsAsync(string filePath)
    {
        var result = new ImportResult();

        // Загружаем кэши
        var products = await _context.Products.ToDictionaryAsync(p => p.Name, p => p.Id);
        var employees = await _context.Employees.ToDictionaryAsync(e => e.FullName, e => e.Id);
        var lines = await _context.EquipmentLines.ToDictionaryAsync(l => l.Name, l => l.Id);

        Console.WriteLine($"Загружено продуктов: {products.Count}");
        Console.WriteLine($"Загружено сотрудников: {employees.Count}");
        Console.WriteLine($"Загружено линий: {lines.Count}");

        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheet(1);
        var rows = worksheet.RangeUsed().RowsUsed();

        int totalRows = rows.Count() - 1;
        result.TotalRows = totalRows;
        Console.WriteLine($"Всего строк в Excel: {totalRows}");

        int rowIndex = 0;
        foreach (var row in rows.Skip(1))
        {
            rowIndex++;
            try
            {
                // Пропускаем пустые строки
                var dateStr = row.Cell(1).GetString();
                if (string.IsNullOrWhiteSpace(dateStr))
                {
                    result.SkippedRows++;
                    continue;
                }

                var record = ParseProductionRow(row, products, employees, lines);
                if (record == null)
                {
                    result.SkippedRows++;
                    continue;
                }

                // Проверяем дубликаты
                bool exists = await _context.ProductionRecords
                    .AnyAsync(p => p.StartTime.Date == record.StartTime.Date
                                && p.SeriesNumber == record.SeriesNumber
                                && p.ProductId == record.ProductId);

                if (exists)
                {
                    result.SkippedRows++;
                    continue;
                }

                await _context.ProductionRecords.AddAsync(record);
                result.InsertedRows++;
            }
            catch (Exception ex)
            {
                result.Errors++;
                Console.WriteLine($"Ошибка в строке {rowIndex}: {ex.Message}");
            }
        }

        await _context.SaveChangesAsync();
        result.Message = $"Импортировано записей: {result.InsertedRows}";

        return result;
    }

    // === ПАРСИНГ СТРОКИ ПРОИЗВОДСТВЕННОЙ ЗАПИСИ ===
    private ProductionRecord ParseProductionRow(
        IXLRangeRow row,
        Dictionary<string, int> products,
        Dictionary<string, int> employees,
        Dictionary<string, int> lines)
    {
        try
        {
            var record = new ProductionRecord();

            // 1. Дата
            var dateStr = row.Cell(1).GetString();
            if (string.IsNullOrWhiteSpace(dateStr))
            {
                Console.WriteLine($"Пропущена строка: пустая дата");
                return null;
            }

            // Берем только дату до пробела (обрезаем время)
            var datePart = dateStr.Trim().Split(' ')[0];

            if (!DateTime.TryParseExact(datePart, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                Console.WriteLine($"Пропущена строка: неверный формат даты '{dateStr}'");
                return null;
            }

            // 6. Смена
            var shiftText = row.Cell(6).GetString()?.Trim() ?? "";
            bool isNight = shiftText.Contains("20:30-08:30");

            if (isNight)
            {
                record.StartTime = date.AddHours(20).AddMinutes(30);
                record.EndTime = date.AddDays(1).AddHours(8).AddMinutes(30);
            }
            else
            {
                record.StartTime = date.AddHours(8).AddMinutes(30);
                record.EndTime = date.AddHours(20).AddMinutes(30);
            }

            // 7. Продукт
            var productName = row.Cell(7).GetString()?.Trim();
            if (string.IsNullOrEmpty(productName))
            {
                Console.WriteLine($"Пропущена строка: пустое имя продукта");
                return null;
            }

            if (!products.TryGetValue(productName, out int productId))
            {
                Console.WriteLine($"Пропущена строка: продукт '{productName}' не найден в БД");
                return null;
            }
            record.ProductId = productId;

            // 8. Линия
            var lineName = row.Cell(8).GetString()?.Trim();
            if (string.IsNullOrEmpty(lineName))
            {
                Console.WriteLine($"Пропущена строка: пустое имя линии");
                return null;
            }

            if (!lines.TryGetValue(lineName, out int lineId))
            {
                Console.WriteLine($"Пропущена строка: линия '{lineName}' не найдена в БД");
                return null;
            }
            record.EquipmentLineId = lineId;

            // 9. Номер серии
            record.SeriesNumber = row.Cell(9).GetString()?.Trim() ?? "";

            // 10. Фактическое количество
            record.ActualQuantity = ParseInt(row.Cell(10).GetString());

            // 22. Время работы оборудования
            var operatingTime = ParseInt(row.Cell(22).GetString());
            if (operatingTime.HasValue && operatingTime.Value > 0)
            {
                record.EndTime = record.StartTime.AddMinutes(operatingTime.Value);
            }

            // 23. Комментарии
            record.Comments = row.Cell(23).GetString()?.Trim();

            // 2-5. Сотрудники
            var senior = row.Cell(2).GetString()?.Trim();
            var opD = row.Cell(3).GetString()?.Trim();
            var opNKL = row.Cell(4).GetString()?.Trim();
            var packer = row.Cell(5).GetString()?.Trim();

            if (!string.IsNullOrEmpty(senior) && employees.TryGetValue(senior, out int seniorId))
                record.SeniorOperatorId = seniorId;

            if (!string.IsNullOrEmpty(opD) && employees.TryGetValue(opD, out int opDId))
                record.OperatorDId = opDId;

            if (!string.IsNullOrEmpty(opNKL) && employees.TryGetValue(opNKL, out int opNKLId))
                record.OperatorNKLId = opNKLId;

            if (!string.IsNullOrEmpty(packer) && employees.TryGetValue(packer, out int packerId))
                record.PackerId = packerId;

            // 11-21. Простои
            var downtimes = new List<DowntimeRecord>();

            // Плановые: Обед(11), МУ(12), ГУ(13), ТО(14), Обучение(15), Старт-стоп(16)
            int[] plannedTypes = { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < plannedTypes.Length; i++)
            {
                int cellIndex = 11 + i;
                var value = ParseInt(row.Cell(cellIndex).GetString());
                if (value.HasValue && value.Value > 0)
                {
                    downtimes.Add(new DowntimeRecord
                    {
                        DowntimeTypeId = plannedTypes[i],
                        DurationMinutes = value.Value
                    });
                }
            }

            // Внеплановые: Механические(17), КИПиА(18), Инженерные(19), Другие(20), Не используется(21)
            int[] unplannedTypes = { 7, 8, 9, 10, 11 };
            for (int i = 0; i < unplannedTypes.Length; i++)
            {
                int cellIndex = 17 + i;
                var value = ParseInt(row.Cell(cellIndex).GetString());
                if (value.HasValue && value.Value > 0)
                {
                    downtimes.Add(new DowntimeRecord
                    {
                        DowntimeTypeId = unplannedTypes[i],
                        DurationMinutes = value.Value
                    });
                }
            }

            record.Downtimes = downtimes;

            Console.WriteLine($"УСПЕШНО: Дата={dateStr}, Продукт={productName}, Серия={record.SeriesNumber}");
            return record;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка парсинга строки: {ex.Message}");
            return null;
        }
    }

    // === ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ===
    private int? ParseInt(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var cleaned = new string(value.Where(c => char.IsDigit(c)).ToArray());
        if (string.IsNullOrEmpty(cleaned))
            return null;

        return int.TryParse(cleaned, out int result) ? result : null;
    }

    private string ExtractEmployeeShortName(string fullName)
    {
        var parts = fullName.Split(' ');
        if (parts.Length >= 2)
            return $"{parts[0]} {parts[1]}";
        return fullName;
    }

    private string ExtractShortName(string fullName)
    {
        var match = Regex.Match(fullName, @"^(.*?)(?:\s+капсулы|\s+таблетки|\s+сироп|\s+раствор)?");
        if (match.Success)
        {
            var baseName = match.Groups[1].Value;
            var packSize = ExtractPackSize(fullName);
            return packSize.HasValue ? $"{baseName} N{packSize}" : baseName;
        }
        return fullName.Length > 30 ? fullName.Substring(0, 30) : fullName;
    }

    private string ExtractDosage(string fullName)
    {
        var match = Regex.Match(fullName, @"(\d+\s*мг|\d+\s*г)");
        return match.Success ? match.Groups[1].Value : null;
    }

    private string ExtractForm(string fullName)
    {
        var match = Regex.Match(fullName, @"(капсулы|таблетки|сироп|раствор)");
        return match.Success ? match.Groups[1].Value : null;
    }

    private int? ExtractPackSize(string fullName)
    {
        var match = Regex.Match(fullName, @"№\s*(\d+)");
        return match.Success ? int.Parse(match.Groups[1].Value) : null;
    }

    private string ExtractLineCode(string lineName)
    {
        if (string.IsNullOrEmpty(lineName))
            return "L0";

        var match = Regex.Match(lineName, @"Линия\s*(\d+)");
        return match.Success ? $"L{match.Groups[1].Value}" : lineName.Substring(0, Math.Min(10, lineName.Length));
    }
}