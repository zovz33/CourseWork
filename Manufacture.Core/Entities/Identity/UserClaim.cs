﻿using Microsoft.AspNetCore.Identity;

namespace Manufacture.Core.Entities.Identity;

public class UserClaim : IdentityUserClaim<int>
{
    public virtual User User { get; set; }
}