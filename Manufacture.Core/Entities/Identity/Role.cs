using Microsoft.AspNetCore.Identity;

namespace Manufacture.Core.Entities.Identity;

public class Role : IdentityRole<int>
{
    public string Description { get; set; }

    public string? CreatedBy { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDateTime { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; }

    public virtual ICollection<RoleClaim> RoleClaims { get; set; }
}