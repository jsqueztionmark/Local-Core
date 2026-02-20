using Local.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Local.Core.Data.Repository
{
    public class IdRepositoryBase<TEntity, TId, TContext> : RepositoryBase<TEntity, TContext>
        where TEntity : IdentityEntity<TId>
        where TId : notnull
        where TContext : DbContext
    {
        public IdRepositoryBase(TContext context) : base(context)
        {
        }

        public virtual TEntity? GetById(TId id)
        {
            var retVal = GetTable().SingleOrDefault(e => e.Id.Equals(id));
            return retVal;
        }
    }
}
