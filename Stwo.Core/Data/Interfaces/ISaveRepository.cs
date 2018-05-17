using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stwo.Core
{
    public interface ISaveRepository<tEntity, tType>
        where tEntity : class, IEntityBase<tType>
        where tType : struct
    {

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <returns></returns>
        Task<tType> AddAsync(tEntity entity);

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync(tEntity entity);

        /// <summary>
        /// Delete the entity.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task HardDelete(tType ID);

        /// <summary>
        /// Mark the object is deleted.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task SoftDelete(tType ID);
    }
}
