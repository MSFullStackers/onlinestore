using System;

namespace online.core
{
    public interface IDiComponent
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
