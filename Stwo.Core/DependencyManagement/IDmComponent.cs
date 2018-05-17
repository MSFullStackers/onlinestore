using System;

namespace Stwo.Core
{
    public interface IDmComponent
    {
         
        object Key
        {
            get;
        }

       
        Lifetime Lifetime
        {
            get;
        }

         
        Type Target
        {
            get;
        }
    }
}
