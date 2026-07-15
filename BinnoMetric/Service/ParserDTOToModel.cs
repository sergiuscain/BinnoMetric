using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;

namespace BinnoMetric.Service;
public static class ParserDTOToModel
{
    // Экспорт DTO в модель
    public static DowntimeRecord ToModel(DowntimeRecordDTO dto)
    {
        return new DowntimeRecord
        {
            DowntimeTypeId = dto.DowntimeTypeId,
            DurationMinutes = dto.DurationMinutes,
            ProductionRecordId = dto.ProductionRecordId,
        };
    }
    public static DowntimeType ToModel(DowntimeTypeDTO dto)
    {
        return new DowntimeType
        {
            IsActive = true,
            IsPlanned = dto.IsPlanned,
            Name = dto.Name,
        };
    }
    public static Employee ToModel(EmployeeDTO dto)
    {
        return new Employee
        {
            FullName = dto.FullName,
            IsActive = true,
            ShortName = dto.FullName.ToShortName()
        };
    }
    public static EquipmentLine ToModel(EquipmentLineDTO dto)
    {
        return new EquipmentLine
        {
            Code = dto.Name,
            Name = dto.Name,
            IsActive = true
        };
    }
    public static Product ToModel(ProductDTO dto)
    {
        return new Product
        {
            Dosage = dto.Dosage,
            Form = dto.Form,
            Name = dto.Name,
            PackSize = dto.PackSize,
            IsActive = true,
            ShortName = dto.Name
        };
    }
    public static ProductionRecord ToModel(ProductionRecordDTO dto)
    {
        return new ProductionRecord
        {
            ActualQuantity = dto.ActualQuantity,
            Comments = dto.Comments,
            Downtimes = new List<DowntimeRecord>(),
            EquipmentLineId = dto.EquipmentLineId,
            CreatedAt = DateTime.Now,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            SeriesNumber = dto.SeriesNumber,
            ProductId = dto.ProductId,
            SeniorOperatorId = dto.SeniorOperatorId,
            OperatorDId = dto.OperatorDId,
            OperatorNKLId = dto.OperatorNKLId,
            PackerId = dto.PackerId,
        };
    }


    // Экспорт полного ФИО в краткий формат типа: Королев.С.С
    public static string ToShortName(this string fullName)
    {
        var parsedNames = fullName.Split(' ');
        var firtstName = parsedNames[1];
        var lastName = parsedNames[0];
        var patronymic = parsedNames[2];
        return $"{lastName}.{firtstName[0]}.{patronymic[0]}";
    }
}
