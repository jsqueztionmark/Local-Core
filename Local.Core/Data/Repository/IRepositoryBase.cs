using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Local.Core.Data.Entity;

namespace ProEnablement.Core.Data.Repository
{
    public interface IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> Create(IEnumerable<TEntity> entities);
        void BatchInsert(IEnumerable<TEntity> entities, int batchSize);
        void BulkInsert(IEnumerable<TEntity> entities);
        void BulkDelete(IEnumerable<TEntity> entities);
		void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
    }
}
