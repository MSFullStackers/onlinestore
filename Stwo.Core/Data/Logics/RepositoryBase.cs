using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Stwo.Core
{
    public abstract class RepositoryBase<tEntity, tType> : IRepositoryBase<tEntity, tType>
        where tEntity : class, IEntityBase<tType>
        where tType : struct
    {

        #region Variables
        private DbSet<tEntity> _dbSet = null;

        protected DbContext DataContext { get; private set; }

        protected IQueryable<tEntity> Entity
        {
            get
            {
                return _dbSet;
            }
        }

        public bool AutoCommitEnabled { get; set; }

        #endregion

        #region Protected Method

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            DataContext = unitOfWork.DataContext;
            _dbSet = DataContext.Set<tEntity>();
        }

        /// <summary>
        /// Virtual method to override the entity with include the dependencies.
        /// </summary>
        /// <returns></returns>
        protected virtual IQueryable<tEntity> GetAllAsyncQuery()
        {
            return Entity;
        }

        #endregion

        #region IRepositoryBase Implementations

        #region IGetRepository Implementations
        async Task<List<tEntity>> IGetRepository<tEntity, tType>.GetAllAsync()
        {
            return await GetAllAsyncQuery().ToListAsync();
        }

        async Task<tEntity> IGetRepository<tEntity, tType>.GetAsync(tType ID)
        {
            return await GetAllAsyncQuery().FirstOrDefaultAsync(r => r.ID.Equals(ID));
        }

        async Task<List<tEntity>> IGetRepository<tEntity, tType>.GetAllPageData
            (Expression<Func<tEntity, bool>> OrderBy, int PageNo, int PageCount)
        {
            return await GetAllAsyncQuery().OrderBy(OrderBy).Skip(PageNo * PageCount).Take(PageCount).ToListAsync();
        }

        async Task<List<tEntity>> IGetRepository<tEntity, tType>.FindByAsync(Expression<Func<tEntity, bool>> predicate)
        {
            return await GetAllAsyncQuery().Where(predicate).ToListAsync();
        }

        async Task<List<tEntity>> IGetRepository<tEntity, tType>.FindByWithPagingAsync
            (Expression<Func<tEntity, bool>> predicate, Expression<Func<tEntity, bool>> OrderBy, int PageNo, int PageCount)
        {
            return await GetAllAsyncQuery().Where(predicate).OrderBy(OrderBy)
                .Skip(PageNo * PageCount).Take(PageCount).ToListAsync();
        }

        #endregion

        #region ISaveRepository Implementations

        async Task<tType> ISaveRepository<tEntity, tType>.AddAsync(tEntity entity)
        {
            if (entity.ID.Equals(null) || entity.ID.Equals(0))
            {
                DataContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                await _dbSet.AddAsync(entity);
            }
            return entity.ID;
        }

        async Task ISaveRepository<tEntity, tType>.UpdateAsync(tEntity entity)
        {
            // Execute update with separate async thread.
            await Task.Run(() => _dbSet.Update(entity));
        }

        async Task ISaveRepository<tEntity, tType>.HardDelete(tType ID)
        {
            tEntity entity = await Entity.FirstOrDefaultAsync(e => e.ID.Equals(ID));
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        async Task ISaveRepository<tEntity, tType>.SoftDelete(tType ID)
        {
            tEntity entity = await Entity.FirstOrDefaultAsync(e => e.ID.Equals(ID));
            if (entity != null)
            {
                entity.IsActive = true;
                DataContext.Entry(entity).State = EntityState.Modified;
            }
        }

        #endregion

        #endregion

    }
}
