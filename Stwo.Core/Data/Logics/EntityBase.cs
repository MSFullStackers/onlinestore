using System;
using System.ComponentModel.DataAnnotations;

namespace Stwo.Core
{
    public abstract class EntityBase<T> : IEntityBase<T>
        where T : struct
    {
        
        [Key]
        public T ID { get; set; }
                
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Restrict concurrency error.
        /// </summary>
        // public byte[] RowVersion { get; set; }
    }
}
