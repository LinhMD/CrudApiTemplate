using CrudApiTemplate.Attributes;
using Microsoft.EntityFrameworkCore;

namespace CrudApiTemplate.View;

public interface IView<TModel> where TModel : class
{
    public IQueryable<TModel> DynamicInclude(IQueryable<TModel> dbSet)
    {
        foreach (var path in GetNavigatePaths(GetType()))
        {
            dbSet.Include(path);
        }
        return dbSet;
    }

    public static List<string> GetNavigatePaths(Type viewType)
    {
        var customAttributes = viewType.GetCustomAttributes(typeof(IncludeAttribute), true);
        var list = new List<string>();
        foreach (IncludeAttribute attribute in customAttributes)
        {
            list.Add(attribute.Path);
        }
        return list;
    }
}