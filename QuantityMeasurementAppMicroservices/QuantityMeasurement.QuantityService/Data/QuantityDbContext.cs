using Microsoft.EntityFrameworkCore;
using QuantityMeasurement.QuantityService.Entities;
namespace QuantityMeasurement.QuantityService.Data;

public class QuantityDbContext : DbContext
{
    public QuantityDbContext(DbContextOptions<QuantityDbContext> options)
        : base(options)
    {
    }

    public DbSet<QuantityMeasurementEntity> QuantityMeasurements { get; set; }

}