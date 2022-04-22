namespace CrudApiTemplate.Request;

public interface ICreateRequest<out TModel> where TModel: class
{
    TModel CreateNew();
    /*{
        var type = typeof(TModel);

        var instance = Activator.CreateInstance(type);

        foreach (var requestProperties in GetType().GetProperties())
        {
            var targetAttribute = Attribute.GetCustomAttribute(requestProperties, typeof(TargetAttribute));
            var modelProperty = type.GetProperty(requestProperties.Name);

        }


        return null;
    }*/
}