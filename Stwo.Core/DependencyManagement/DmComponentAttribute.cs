using System;

namespace Stwo.Core
{
    public class DmComponentAttribute : Attribute, IDmComponent
    {
        public DmComponentAttribute(Type serviceType = null, Lifetime lifetime = Lifetime.Singleton, object key = null, bool enumerationOnly = false)
        {
            this.Target = serviceType;
            this.Lifetime = lifetime;
            this.Key = key;
            this.EnumerationOnly = enumerationOnly;
        }
      
        public bool EnumerationOnly
        {
            get; set;
        }

        public object Key
        {
            get; set;
        }

        public Lifetime Lifetime
        {
            get; set;
        }

       
        public Type Target
        {
            get;
            set;
        }
    }
}