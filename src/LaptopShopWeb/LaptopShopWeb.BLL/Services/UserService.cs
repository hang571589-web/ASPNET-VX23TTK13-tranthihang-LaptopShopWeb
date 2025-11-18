using LaptopShopWeb.BLL.DTOs;
using LaptopShopWeb.BLL.Mappers;
using LaptopShopWeb.DAL.UnitOfWork;
using LaptopShopWeb.Entity;
using BCrypt.Net;

namespace LaptopShopWeb.BLL.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        return user?.ToDto();
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        // Alias method
        return await GetUserByIdAsync(id);
    }

    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(email);
        return user?.ToDto();
    }

    public async Task<List<UserDto>> GetUsersByRoleAsync(string role)
    {
        var users = await _unitOfWork.Users.GetUsersByRoleAsync(role);
        return users.Select(u => u.ToDto()).ToList();
    }

    public async Task<UserDto> RegisterAsync(string email, string password, string fullName, 
        string? phoneNumber, string? address)
    {
        // Check if email exists
        if (await _unitOfWork.Users.EmailExistsAsync(email))
            throw new Exception("Email already exists");

        // Hash password
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        // Create user
        var user = new User
        {
            Email = email,
            PasswordHash = hashedPassword,
            FullName = fullName,
            PhoneNumber = phoneNumber,
            Address = address,
            Role = "Customer",
            IsActive = true
        };

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return user.ToDto();
    }

    public async Task<UserDto?> LoginAsync(string email, string password)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(email);
        
        if (user == null || !user.IsActive)
            return null;

        // Verify password
        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;

        return user.ToDto();
    }

    public async Task<UserDto> UpdateProfileAsync(int userId, string fullName, string? phoneNumber, string? address)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null)
            throw new Exception("User not found");

        user.FullName = fullName;
        user.PhoneNumber = phoneNumber;
        user.Address = address;

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return user.ToDto();
    }

    public async Task UpdateAsync(int userId, UpdateUserDto updateDto)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null)
            throw new Exception("User not found");

        user.FullName = updateDto.FullName;
        user.PhoneNumber = updateDto.PhoneNumber;
        user.Address = updateDto.Address;

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null)
            return false;

        // Verify old password
        if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.PasswordHash))
            return false;

        // Hash new password
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task ChangePasswordAsync(int userId, string hashedPassword)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null)
            throw new Exception("User not found");

        user.PasswordHash = hashedPassword;

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _unitOfWork.Users.EmailExistsAsync(email);
    }

    public async Task<bool> UpdateUserRoleAsync(int userId, string role)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null)
            return false;

        user.Role = role;
        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ToggleUserStatusAsync(int userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null)
            return false;

        user.IsActive = !user.IsActive;
        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
