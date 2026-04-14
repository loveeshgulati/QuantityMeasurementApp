using Microsoft.EntityFrameworkCore;
using QuantityMeasurement.AuthService.Entities;
namespace QuantityMeasurement.AuthService.Data;
public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }
     public DbSet<UserEntity> Users { get; set; }

}