using Microsoft.AspNetCore.Identity;

namespace Manufacture.Core.Entities.Identity;

public class UserLogin : IdentityUserLogin<int>
{
    public virtual User User { get; set; }
}