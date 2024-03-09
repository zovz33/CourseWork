using Manufacture.BusinessLogic.Interfaces;
using Manufacture.Core.Entities.Identity;
using Manufacture.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Services;

public class RoleService : IRoleService
{
    private readonly IApplicationDbContext _context;
    private readonly RoleManager<Role> _roleManager;
    public RoleService(ApplicationDbContext context, RoleManager<Role> roleManager)
    {
        _context = context;
        _roleManager = roleManager;
    }
    
    public async Task<List<Role>> GetRoles()
    {
        return await _context.Roles.ToListAsync();
    }
    
    public async Task<Role> GetRoleById(int? id)
    {
        return await _context.Roles.FindAsync(id);
    }
    
    public async Task Add(Role entity, int adminId)
    { 
        await _roleManager.CreateAsync(entity);
        entity.CreatedBy = adminId;
        entity.UpdatedBy = 0;
        entity.CreatedDateTime = DateTime.Now;
        await _context.SaveChangesAsync();
    }

    public async Task Update(Role role, int id, int adminId)
    {
        var entity = await _context.Roles.FindAsync(id);
        if (entity != null)
        {
            entity.Name = role.Name;
            if (!string.IsNullOrEmpty(role.Name))
            {
                await _roleManager.UpdateAsync(entity);
            }
            entity.Description = role.Description;
            entity.UpdatedBy = adminId;
            entity.UpdatedDateTime = DateTime.Now;

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
    
}