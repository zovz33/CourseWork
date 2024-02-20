using Microsoft.AspNetCore.Identity;

namespace Manufacture.Core.Entities.Identity;

public class RoleClaim : IdentityRoleClaim<int>
{
    public virtual Role Role { get; set; }
}