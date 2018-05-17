using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stwo.Core
{
    [DmComponent(Lifetime = Lifetime.Singleton, Target = typeof(IUnitOfWork))]
    public class UnitOfWork : IUnitOfWork
    {

        #region Fields
        private readonly DbContext _dbContext;
        #endregion

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        DbContext IUnitOfWork.DataContext
        {
            get
            {
                return _dbContext;
            }
        }

        async Task<List<string>> IUnitOfWork.CommitAsync()
        {
            List<string> exceptions = new List<string>();
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                exceptions.Add(ex.Message);
            }
            return exceptions;
        }

        void IDisposable.Dispose() => _dbContext.Dispose();

    }
}
