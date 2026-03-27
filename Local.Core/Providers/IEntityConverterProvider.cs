using Local.Core.Mapping;

namespace Local.Core.Providers;

public interface IEntityConverterProvider
{
    IEntityConverter<TEntity, TModel> GetConverter<TEntity, TModel>()
        where TEntity : class
        where TModel : class;
}
