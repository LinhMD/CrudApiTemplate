using CrudApiTemplate.Attributes;
using CrudApiTemplate.CustomException;
using CrudApiTemplate.Repositories;

namespace CrudApiTemplate.Request;

public interface ICreateRequest<TModel> where TModel: class
{
    virtual TModel CreateNew(IUnitOfWork work)
    {
        var type = typeof(TModel);

        var instance = Activator.CreateInstance(type);

        foreach (var requestProperties in this.GetType().GetProperties())
        {
            var propertyValue = requestProperties.GetValue(this);
            if(propertyValue is null) continue;

            var modelPathAttribute = Attribute.GetCustomAttribute(requestProperties, typeof(ModelPathAttribute)) as ModelPathAttribute;
            var modelProperty = type.GetProperty(modelPathAttribute?.Path ?? requestProperties.Name);

            if (modelProperty is null)
                throw new CodingException($"Coding error: property of {nameof(TModel)} not found with name {modelPathAttribute?.Path ?? requestProperties.Name}");

            modelProperty.SetValue(instance, propertyValue);
        }


        return (instance as TModel)!;
    }
}