using System.Security.Claims;
using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities.Identity;
using Manufacture.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public UserService(
        ApplicationDbContext context,
        UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }


    public async Task<User> GetUserById(int? id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddUser(User user)
    {
        var adminId = await GetCurrentUserIdAsync();
        await _userManager.CreateAsync(user);
        user.CreatedBy = adminId;
        user.CreatedDateTime = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(User user, int id)
    {
        var adminId = await GetCurrentUserIdAsync();
        var entity = await _context.Users.FindAsync(id);
 
        if (entity != null)
        {
            entity.UserName = user.UserName;
            if (!string.IsNullOrEmpty(user.PasswordHash) && user.PasswordHash != entity.PasswordHash)
            {
                // Сброс пароля и установка нового пароля
                var token = await _userManager.GeneratePasswordResetTokenAsync(entity);
                await _userManager.ResetPasswordAsync(entity, token, user.PasswordHash);
            }

            entity.FirstName = user.FirstName;
            entity.MiddleName = user.MiddleName;
            entity.LastName = user.LastName;
            entity.Gender = user.Gender;
            entity.Address = user.Address;
            entity.HomePhone = user.HomePhone;
            entity.PhoneNumber = user.PhoneNumber;
            entity.DateOfBirth = user.DateOfBirth;
            entity.ProfileImage = user.ProfileImage;
            entity.UpdatedBy = adminId;
            entity.UpdatedDateTime = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<string> FindNameById(int? createdById)
    {
        var user = await _context.Users.FindAsync(createdById);
        return user?.UserName ?? "Система";
    }

    public async Task<int> GetCurrentUserIdAsync()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim != null && int.TryParse(userIdClaim, out int userId))
        {
            return userId;
        }

        return 0;
    }

    public async Task<User> GetCurrentUserAsync()
    {
        var id = await GetCurrentUserIdAsync();
        if (id != null)
            return await _context.Users.FindAsync(id);
        else
            return null;
    }
    
    public async Task<string> GetUserNameById(int? userId)
    {
        if (userId == null || userId == 0)
        {
            return "Система";
        }
        var userName = await FindNameById(userId);
        return userName ?? "Система";
    }


     
}