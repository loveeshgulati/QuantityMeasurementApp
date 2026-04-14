using QuantityMeasurement.AuthService.Entities;
namespace QuantityMeasurement.AuthService.Interfaces;
public interface IUserRepository
{
    Task<UserEntity?> GetByEmailAsync(string email);
    Task<UserEntity> AddUserAsync(UserEntity user);
}