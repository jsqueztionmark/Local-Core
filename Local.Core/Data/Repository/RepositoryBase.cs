using Microsoft.EntityFrameworkCore;
using System.Transactions;
//using EFCore.BulkExtensions;
using Local.Core.Data.Entity;
using ProEnablement.Core.Data.Repository;

namespace Local.Core.Data.Repository
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
        where TContext : DbContext
    {
        protected readonly TContext _db;
        protected DbSet<TEntity> _dbSet;

        public RepositoryBase(TContext context)
        {
            _db = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Create(TEntity entity)
        {
            _dbSet.Add(entity);
            SaveChanges();
            return entity;
        }

        public virtual IEnumerable<TEntity> Create(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
				_dbSet.Add(entity);
			SaveChanges();
			return entities;
        }

        public virtual void BatchInsert(IEnumerable<TEntity> entities, int batchSize)
        {
            var grouped = entities.Chunk(batchSize).ToList();

			using (TransactionScope scope = new TransactionScope())
			{
                foreach (var group in grouped)
                {
					foreach (var entity in group)						
						_dbSet.Add(entity);
					SaveChanges();
				}
                
				scope.Complete();
			}
		}

        public virtual void BulkInsert(IEnumerable<TEntity> entities)
        {
            //_db.BulkInsert(entities);
            throw new NotImplementedException();
        }

        public virtual void BulkDelete(IEnumerable<TEntity> entities)
        {
            //_db.BulkDelete(entities);
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            var entry = _db.Entry(entity);
            entry.State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                Update(e);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            SaveChanges();
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Delete(entity);
            }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        protected int SaveChanges()
        {
            return _db.SaveChanges();
        }

        protected DbSet<TEntity> GetTable()
        { 
            return _dbSet; 
        }

		protected IQueryable<TEntity> GetTableAsNoTracking()
		{
			return _dbSet.AsNoTracking();
		}
	}
}
