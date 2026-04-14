using QuantityMeasurement.AuthService.Data;
using QuantityMeasurement.AuthService.Entities;
using Microsoft.EntityFrameworkCore;
using QuantityMeasurement.AuthService.Interfaces;
namespace QuantityMeasurement.AuthService.Repository;
public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _context;

    public UserRepository(AuthDbContext context) => _context = context;

    public async Task<UserEntity?> GetByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<UserEntity> AddUserAsync(UserEntity user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}