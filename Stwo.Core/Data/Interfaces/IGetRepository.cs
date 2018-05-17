﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stwo.Core
{
    public interface IGetRepository<tEntity, tType>
        where tEntity : class, IEntityBase<tType>
        where tType : struct
    {
        /// <summary>
        /// Get the entity By ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<tEntity> GetAsync(tType ID);

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns></returns>
        Task<List<tEntity>> GetAllAsync();

        /// <summary>
        /// Get entities for specific page
        /// </summary>
        /// <param name="OrderBy">Order by column predicate</param>
        /// <param name="PageNo">Current page number</param>
        /// <param name="PageCount">Number of entities need to fetch</param>
        /// <returns></returns>
        Task<List<tEntity>> GetAllPageData(Expression<Func<tEntity, bool>> OrderBy, int PageNo = 0, int PageCount = 20);

        /// <summary>
        /// Find entities based on condition
        /// </summary>
        /// <param name="Predicate">Predicate condition </param>
        /// <returns>List of entity</returns>
        Task<List<tEntity>> FindByAsync(Expression<Func<tEntity, bool>> predicate);

        /// <summary>
        /// Get entities for specific page based on contition
        /// </summary>
        /// <param name="Predicate">Condition predicate</param>
        /// <param name="OrderBy">Order by column predicate</param>
        /// <param name="PageNo">Current page number</param>
        /// <param name="PageCount">Number of entities need to fetch</param>
        /// <returns></returns>
        Task<List<tEntity>> FindByWithPagingAsync(Expression<Func<tEntity, bool>> predicate, Expression<Func<tEntity, bool>> OrderBy, int PageNo = 0, int PageCount = 20);
    }
}
