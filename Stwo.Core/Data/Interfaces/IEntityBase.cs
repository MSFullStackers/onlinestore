using System;
using System.Collections.Generic;
using System.Text;

namespace Stwo.Core
{
    public interface IEntityBase<T>
        where T : struct
    {

        /// <summary>
        /// Primary key of Entity.
        /// </summary>
        T ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
		/// Restrict concurrency error.
		/// </summary>
		// byte[] RowVersion { get; set; }
    }
}
