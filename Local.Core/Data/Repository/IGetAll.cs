using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Local.Core.Data.Entity;

namespace Local.Core.Data.Repository;

public interface IGetAll<TEntity>
    where TEntity : EntityBase
{
    /// <summary>
    /// Protected access for full table read of a specific entity type
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetAll();
}