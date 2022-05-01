using System.Linq.Expressions;
using System.Reflection;
using CrudApiTemplate.Attributes.Search;

namespace CrudApiTemplate.Request;

public interface IFindRequest<TModel> where TModel: class
{
    virtual Expression<Func<TModel, bool>> ToPredicate()
    {
        var param = Expression.Parameter(typeof(TModel), typeof(TModel).Name);
        Expression expressionBody = Expression.Constant(true);
        foreach (var property in GetType().GetProperties())
        {
            var value = property?.GetValue(this);
            if(value is null) continue;

            Expression expression = default;

            Expression tProperty;
            FilterAttribute[] filters = Attribute.GetCustomAttributes(property!, typeof(FilterAttribute)) as FilterAttribute[] ?? Array.Empty<FilterAttribute>();
            if (filters.Any())
            {
                foreach (var filter in filters)
                {
                    var list = filter.Target?.Split(".").ToList();
                    //ex: t.Name
                    tProperty = Navigate(param, list, property);

                    expression = filter.ToExpressionEvaluate(tProperty, value);
                }
            }
            else
            {
                tProperty = Expression.Property(param, property!.Name);
                expression = Expression.Equal(tProperty, Expression.Constant(value));
            }

            expressionBody = Expression.And(expressionBody, expression!);
        }

        //ex: t => ((t.Name == "nah") && (t.Role.Name == "admin"))
        var lambda = Expression.Lambda<Func<TModel, bool>>(expressionBody, param);
        Console.WriteLine(lambda);
        return lambda;
    }

    private static Expression Navigate(ParameterExpression param, List<string>? list, PropertyInfo? property)
    {
        Expression tProperty = Expression.Property(param, list?[0] ?? property!.Name);
        //if have more member navigation like t.Role.Name
        if (list != null)
        {
            foreach (var propertyName in list.Skip(1))
            {
                tProperty = Expression.PropertyOrField(tProperty, propertyName);
            }
        }

        return tProperty;
    }
}