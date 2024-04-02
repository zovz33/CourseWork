using System.Security.Claims;
using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities;
using Manufacture.Core.Entities.Identity;
using Manufacture.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Services;

public class RoleService : IRoleService
{
    private readonly IApplicationDbContext _context;
    private readonly RoleManager<Role> RoleManager;
    private readonly IUserService userService;

    public RoleService(ApplicationDbContext context, RoleManager<Role> roleManager, IUserService UserService)
    {
        userService = UserService;
        _context = context;
        RoleManager = roleManager;
    }

    private Dictionary<string, string> GlobalPermissions { get; set; } = new();

    public async Task<List<Role>> GetRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role> GetRoleById(int? id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task Add(Role role, IEnumerable<string> selectedPermissions)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        if (role != null)
        {
            role.CreatedBy = adminId;
            role.UpdatedBy = 0;
            role.CreatedDateTime = DateTime.UtcNow;
        }

        await RoleManager.CreateAsync(role);
        foreach (var permission in selectedPermissions)
        {
            var claim = new Claim("Permission1", permission);
            await RoleManager.AddClaimAsync(role, claim);
        }

        await _context.SaveChangesAsync();
    }


    public async Task Update(Role role, IEnumerable<string> selectedPermissions)
    {
        var adminId = await userService.GetCurrentUserIdAsync();
        var entity = await _context.Roles
            .Include(r => r.RoleClaims)
            .FirstOrDefaultAsync(r => r.Id == role.Id);

        if (entity != null)
        {
            entity.Name = role.Name;
            entity.Description = role.Description;
            entity.UpdatedBy = adminId;
            entity.UpdatedDateTime = DateTime.UtcNow;

            var oldPermission = await _context.Roles
                .Include(r => r.RoleClaims)
                .FirstOrDefaultAsync(r => r.Id == role.Id);

            foreach (var claim in oldPermission.RoleClaims)
                await RoleManager.RemoveClaimAsync(role, new Claim(claim.ClaimType, claim.ClaimValue));

            // Добавляем новые права доступа из SelectedPermissions
            foreach (var permission in selectedPermissions)
            {
                var claim = new Claim("Permission1", permission);
                await RoleManager.AddClaimAsync(role, claim);
            }

            await _context.SaveChangesAsync();
        }
    }


    public async Task Delete(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role != null)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<string>> GetPermissionsByRoleIdAsync(int roleId)
    {
        return await _context.RoleClaims
            .Where(rc => rc.RoleId == roleId && rc.ClaimType == "Permission1")
            .Select(rc => rc.ClaimValue)
            .Distinct()
            .ToListAsync();
    }

    public async Task AddPermissionAsync(Role role, Claim permission)
    {
        // Проверяем, что у данной роли нет уже такого ClaimValue с типом "Permission1"
        var existingClaim = await _context.RoleClaims
            .FirstOrDefaultAsync(rc =>
                rc.RoleId == role.Id && rc.ClaimType == "Permission1" && rc.ClaimValue == permission.Value);

        if (existingClaim != null)
            throw new InvalidOperationException("Данное право доступа уже существует у этой роли.");

        var claim = new RoleClaim
        {
            RoleId = role.Id,
            ClaimType = "Permission2", // Указываем явно тип утверждения
            ClaimValue = permission.Value
        };
        _context.RoleClaims.Add(claim);
        await _context.SaveChangesAsync();
    }


    public async Task RemovePermissionAsync(Role role, Claim permission)
    {
        var claim = await _context.RoleClaims
            .FirstOrDefaultAsync(rc =>
                rc.RoleId == role.Id && rc.ClaimType == "Permission" && rc.ClaimValue == permission.Value);

        if (claim != null)
        {
            _context.RoleClaims.Remove(claim);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Dictionary<string, string>> GetGlobalPermissions()
    {
        var permissionsList = Permissions.GetRegisteredPermissions();
        GlobalPermissions = permissionsList.ToDictionary(
            p => p,
            p =>
            {
                var split = p.Split('.');
                return split.Length > 1 ? split[1] : p;
            });
        return GlobalPermissions;
    }
}