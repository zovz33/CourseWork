using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities.Identity;
using Manufacture.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IApplicationDbContext _context;
    private UserManager<User> _userManager;

    public UserService(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }


    public async Task<User> GetUserById(int? id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddUser(User user, int adminId)
    {
        // await _context.Users.AddAsync(user);
        await _userManager.CreateAsync(user);
        user.CreatedBy = adminId;
        user.CreatedDateTime = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(User user, int id, int adminId)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity != null)
        {
            entity.UserName = user.UserName;
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                await _userManager.UpdateAsync(entity);
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
    
    
}