using Local.Core.Data.Entity;

namespace Local.Core.Data.Repository
{
    public interface IGetByID<TEntity, TId>
        where TEntity : class, IIdentityEntity<TId>
    {
        TEntity? GetById(TId id);
    }
}
