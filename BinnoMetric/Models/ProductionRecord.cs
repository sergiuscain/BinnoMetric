namespace BinnoMetric.Models;
public class ProductionRecord
{
    public int Id { get; set; }

    // Время начала и окончания работы над серией
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public int ProductId { get; set; }
    public int EquipmentLineId { get; set; }
    public string SeriesNumber { get; set; }
    public int? ActualQuantity { get; set; }
    public string Comments { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    // Сотрудники с указанием зоны работы
    public int? SeniorOperatorId { get; set; } // Старший оператор
    public int? OperatorDId { get; set; } // Оператор в зоне D
    public int? OperatorNKLId { get; set; } // Оператор в зоне НКЛ
    public int? PackerId { get; set; } // Укладчик-упаковщик

    // Навигационные свойства
    public Product Product { get; set; }
    public EquipmentLine EquipmentLine { get; set; }
    public Employee SeniorOperator { get; set; }
    public Employee OperatorD { get; set; }
    public Employee OperatorNKL { get; set; }
    public Employee Packer { get; set; }
    public ICollection<DowntimeRecord> Downtimes { get; set; }
}
