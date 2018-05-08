using System.Collections.Generic;

namespace online.core
{ 
    public interface IOnlineshopdataContext  
    {
       object GetList<T>();
    }
}