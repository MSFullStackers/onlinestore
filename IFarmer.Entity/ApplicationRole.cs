using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace IFarmer.Entity
{
    // TODO : Role based auth
    public class ApplicationRole : IdentityRole
    {
         public virtual ICollection<IdentityUserRole<string>> Users {get;set;}

         public virtual ICollection<IdentityUserRole<string>> Claims {get;set;}
    }
}