using System.Security.Claims;
using Manufacture.Core.Entities.Identity;

namespace Manufacture.BusinessLogic.Interfaces;

public interface IRoleService
{
    Task<List<Role>> GetRoles();
    Task<Role> GetRoleById(int? id);
    Task Delete(int id);
    Task Add(Role entity, int adminId, IEnumerable<string> selectedPermissions);
    Task Update(Role role, int adminId, IEnumerable<string> selectedPermissions);
    Task<List<string>> GetPermissionsByRoleIdAsync(int roleId);
    Task<Dictionary<string, string>> GetGlobalPermissions();
    Task AddPermissionAsync(Role role, Claim claim);
    Task RemovePermissionAsync(Role role, Claim claim);
}