using BinnoMetric.DataBase.Models;
using BinnoMetric.DTO;

namespace BinnoMetric.Service;
public static class ParserDTOToModel
{
    // Экспорт DTO в модель
    public static DowntimeRecord ToModel(this DowntimeRecordDTO dto)
    {
        return new DowntimeRecord
        {
            DowntimeTypeId = dto.DowntimeTypeId,
            DurationMinutes = dto.DurationMinutes,
            ProductionRecordId = dto.ProductionRecordId,
        };
    }
    public static DowntimeType ToModel(this DowntimeTypeDTO dto)
    {
        return new DowntimeType
        {
            IsActive = true,
            IsPlanned = dto.IsPlanned,
            Name = dto.Name,
        };
    }
    public static Employee ToModel(this EmployeeDTO dto)
    {
        return new Employee
        {
            FullName = dto.FullName,
            IsActive = true,
            ShortName = dto.FullName.ToShortName()
        };
    }
    public static EquipmentLine ToModel(this EquipmentLineDTO dto)
    {
        return new EquipmentLine
        {
            Code = dto.Name,
            Name = dto.Name,
            IsActive = true
        };
    }
    public static Product ToModel(this ProductDTO dto)
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
    public static ProductionRecord ToModel(this ProductionRecordDTO dto)
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



    // Экспорт модели в DTO для отображения
    public static DowntimeRecordDTO ToDTO(this DowntimeRecord model)
    {
        return new DowntimeRecordDTO
        {
            DowntimeTypeId = model.DowntimeTypeId,
            DurationMinutes = model.DurationMinutes,
            ProductionRecordId = model.ProductionRecordId,
        };
    }
    public static DowntimeTypeDTO ToDTO(this DowntimeType model)
    {
        return new DowntimeTypeDTO
        {
            IsPlanned = model.IsPlanned,
            Name = model.Name,
        };
    }
    public static EmployeeDTO ToDTO(this Employee model)
    {
        return new EmployeeDTO
        {
            FullName = model.FullName,
        };
    }
    public static EquipmentLineDTO ToDTO(this EquipmentLine model)
    {
        return new EquipmentLineDTO
        {
            Name = model.Name,
        };
    }
    public static ProductDTO ToDTO(this Product model)
    {
        return new ProductDTO
        {
            Dosage = model.Dosage,
            Form = model.Form,
            Name = model.Name,
            PackSize = model.PackSize,
            Id = model.Id,
        };
    }
    public static ProductionRecordDTO ToDTO(this ProductionRecord model)
    {
        return new ProductionRecordDTO
        {
            ActualQuantity = model.ActualQuantity,
            Comments = model.Comments,
            EquipmentLineId = model.EquipmentLineId,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            SeriesNumber = model.SeriesNumber,
            ProductId = model.ProductId,
            SeniorOperatorId = model.SeniorOperatorId,
            OperatorDId = model.OperatorDId,
            OperatorNKLId = model.OperatorNKLId,
            PackerId = model.PackerId,
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
