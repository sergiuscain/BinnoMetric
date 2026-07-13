using BinnoMetric.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BinnoMetric.DataBase;

public class BinnoDBContext : DbContext
{
    public BinnoDBContext(DbContextOptions<BinnoDBContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<EquipmentLine> EquipmentLines { get; set; }
    public DbSet<DowntimeType> DowntimeTypes { get; set; }
    public DbSet<ProductionRecord> ProductionRecords { get; set; }
    public DbSet<DowntimeRecord> DowntimeRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.FullName)
            .IsUnique();

        modelBuilder.Entity<EquipmentLine>()
            .HasIndex(e => e.Name)
            .IsUnique();

        modelBuilder.Entity<ProductionRecord>()
            .HasOne(p => p.Product)
            .WithMany()
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductionRecord>()
            .HasOne(p => p.EquipmentLine)
            .WithMany()
            .HasForeignKey(p => p.EquipmentLineId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DowntimeRecord>()
            .HasOne(d => d.ProductionRecord)
            .WithMany(p => p.Downtimes)
            .HasForeignKey(d => d.ProductionRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DowntimeRecord>()
            .HasOne(d => d.DowntimeType)
            .WithMany()
            .HasForeignKey(d => d.DowntimeTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductionRecord>()
            .HasIndex(p => p.StartTime);

        modelBuilder.Entity<ProductionRecord>()
            .HasIndex(p => p.SeriesNumber);

        modelBuilder.Entity<ProductionRecord>()
            .HasIndex(p => new { p.ProductId, p.StartTime });

        modelBuilder.Entity<ProductionRecord>()
            .HasIndex(p => p.SeniorOperatorId);

        modelBuilder.Entity<ProductionRecord>()
            .HasIndex(p => p.OperatorDId);

        modelBuilder.Entity<ProductionRecord>()
            .HasIndex(p => p.OperatorNKLId);

        modelBuilder.Entity<ProductionRecord>()
            .HasIndex(p => p.PackerId);

        modelBuilder.Entity<DowntimeType>().HasData(
            new DowntimeType { Id = 1, Name = "Обед", IsPlanned = true },
            new DowntimeType { Id = 2, Name = "МУ", IsPlanned = true },
            new DowntimeType { Id = 3, Name = "ГУ", IsPlanned = true },
            new DowntimeType { Id = 4, Name = "ТО", IsPlanned = true },
            new DowntimeType { Id = 5, Name = "Обучение", IsPlanned = true },
            new DowntimeType { Id = 6, Name = "Старт-стоп", IsPlanned = true },
            new DowntimeType { Id = 7, Name = "Механические неисправности", IsPlanned = false },
            new DowntimeType { Id = 8, Name = "Неисправность КИПиА", IsPlanned = false },
            new DowntimeType { Id = 9, Name = "Неисправность инженерных систем", IsPlanned = false },
            new DowntimeType { Id = 10, Name = "Другие причины", IsPlanned = false },
            new DowntimeType { Id = 11, Name = "Оборудование не используется", IsPlanned = false }
        );
    }
}