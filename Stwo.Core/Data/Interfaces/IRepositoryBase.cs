using System;
using System.Collections.Generic;
using System.Text;

namespace Stwo.Core
{
    public interface IRepositoryBase<tEntity, tType> : IGetRepository<tEntity, tType>, ISaveRepository<tEntity, tType>
           where tEntity : class, IEntityBase<tType>
           where tType : struct
    { }
}
