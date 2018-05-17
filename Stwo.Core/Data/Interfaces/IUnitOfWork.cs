using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stwo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
		/// Commit the current changes in database.
		/// </summary>
		/// <returns></returns>
		Task<List<string>> CommitAsync();

        /// <summary>
        /// Database context object.
        /// </summary>
        DbContext DataContext { get; }
    }
}
