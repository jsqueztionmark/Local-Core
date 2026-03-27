namespace Local.Core.Mapping;

public interface IEntityConverter<TEntity, TModel>
{
    TModel? ToModel(TEntity? entity);
    TEntity? ToEntity(TModel? model);
    IEnumerable<TModel?> ToModels(IEnumerable<TEntity?> entities);
    IEnumerable<TEntity?> ToEntities(IEnumerable<TModel?> models);
}
