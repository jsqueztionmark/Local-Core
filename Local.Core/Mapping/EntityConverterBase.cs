using Local.Core.Exception;

namespace Local.Core.Mapping;

public abstract class EntityConverterBase<TEntity, TModel> : IEntityConverter<TEntity, TModel>
    where TEntity : class
    where TModel : class
{
    public EntityConverterBase() { }

    public virtual TEntity? ToEntity(TModel? model)
    {
        try
        {
            if (model == null) return null;
            var cProps = model.GetType().GetProperties();
            var entity = Activator.CreateInstance(typeof(TEntity));
            if (entity == null) return null;
            var eProps = entity.GetType().GetProperties();

            foreach (var prop in eProps)
            {
                var cProp = cProps.SingleOrDefault(p => p.Name.Equals(prop.Name));
                if (cProp == null) continue;
                var newValue = cProp.GetValue(model);
                var canTransferValue = prop.PropertyType.IsAssignableFrom(cProp.PropertyType) && prop.CanWrite;

                if (canTransferValue)
                    prop.SetValue(entity, newValue);
            }

            return entity as TEntity;
        }
        catch (System.Exception ex)
        {
            var msg = $"Error in ToEntity base for component type {model?.GetType().FullName}.";
            throw new EntityMappingException(msg, ex);
        }
    }

    public virtual TModel? ToModel(TEntity? entity)
    {
        try
        {
            if (entity == null) return null;
            var eProps = entity.GetType().GetProperties();
            var comp = Activator.CreateInstance(typeof(TModel));
            if (comp == null) return null;
            var cProps = comp.GetType().GetProperties();

            foreach (var prop in cProps)
            {
                var eProp = eProps.SingleOrDefault(p => p.Name.Equals(prop.Name));
                if (eProp == null) continue;
                var newValue = eProp.GetValue(entity);
                var canTransferValue = prop.PropertyType.IsAssignableFrom(eProp.PropertyType) && prop.CanWrite;

                if (canTransferValue)
                    prop.SetValue(comp, newValue);
            }

            return comp as TModel;
        }
        catch (System.Exception ex)
        {
            var msg = $"Error in ToComponent base for entity type {entity?.GetType().FullName}.";
            throw new EntityMappingException(msg, ex);
        }
    }

    public virtual IEnumerable<TModel?> ToModels(IEnumerable<TEntity?> entities)
    {
        if(entities == null || !entities.Any()) return new List<TModel?>();    
        try
        {
            var mList = new List<TModel?>();
            foreach (var entity in entities) mList.Add(ToModel(entity));
            return mList;
        }
        catch (System.Exception ex)
        {
            var msg = $"Error in ToComponents base for entity type {entities.First()!.GetType().FullName}.";
            throw new EntityMappingException(msg, ex);
        }
    }

    public virtual IEnumerable<TEntity?> ToEntities(IEnumerable<TModel?> models)
    {
        if(models == null || !models.Any()) return new List<TEntity?>();
        try
        {
            var eList = new List<TEntity?>();
            foreach (var model in models) eList.Add(ToEntity(model));
            return eList;
        }
        catch (System.Exception ex)
        {
            var msg = $"Error in ToEntities base for component type {models.First()!.GetType().FullName}.";
            throw new EntityMappingException(msg, ex);
        }
    }
}
