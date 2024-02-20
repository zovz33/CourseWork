using Microsoft.AspNetCore.Identity;

namespace Manufacture.Core.Entities.Identity;

public class UserToken : IdentityUserToken<int>
{
    public virtual User User { get; set; }
}