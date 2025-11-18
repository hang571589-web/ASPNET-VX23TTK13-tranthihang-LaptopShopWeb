using LaptopShopWeb.BLL.DTOs;

namespace LaptopShopWeb.BLL.Services;

public interface IUserService
{
    Task<UserDto?> GetUserByIdAsync(int id);
    Task<UserDto?> GetByIdAsync(int id); // Alias
    Task<UserDto?> GetUserByEmailAsync(string email);
    Task<List<UserDto>> GetUsersByRoleAsync(string role);
    Task<UserDto> RegisterAsync(string email, string password, string fullName, string? phoneNumber, string? address);
    Task<UserDto?> LoginAsync(string email, string password);
    Task<UserDto> UpdateProfileAsync(int userId, string fullName, string? phoneNumber, string? address);
    Task UpdateAsync(int userId, UpdateUserDto updateDto);
    Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    Task ChangePasswordAsync(int userId, string hashedPassword);
    Task<bool> EmailExistsAsync(string email);
    Task<bool> UpdateUserRoleAsync(int userId, string role);
    Task<bool> ToggleUserStatusAsync(int userId);
}
