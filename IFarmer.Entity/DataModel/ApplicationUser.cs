using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace IFarmer.Entity
{
    // TODO : Role based auth
    public class ApplicationUser : IdentityUser
    {
         public virtual ICollection<IdentityUserRole<string>> Claims {get;set;}

         public virtual ICollection<IdentityUserRole<string>> Roles {get;set;}
    }
}
