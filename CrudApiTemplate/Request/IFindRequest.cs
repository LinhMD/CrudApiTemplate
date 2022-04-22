using System.Linq.Expressions;
using CrudApiTemplate.Attributes.Search;

namespace CrudApiTemplate.Request;

public interface IFindRequest<TModel> where TModel: class
{
    Expression<Func<TModel, bool>> ToPredicate()
    {
        var param = Expression.Parameter(typeof(TModel), "t");
        Expression expressionBody = Expression.Constant(true);
        foreach (var property in GetType().GetProperties())
        {
            var value = property?.GetValue(this);
            if(value is null) continue;

            Expression expression;

            Expression tProperty;
            if (Attribute.GetCustomAttribute(property!, typeof(FilterAttribute)) is FilterAttribute filter)
            {

                var list = filter.Target?.Split(".").ToList()!;
                //ex: t.Name
                tProperty = Expression.Property(param, list?[0] ?? property!.Name);
                //if have more member navigation like t.Role.Name
                if (list != null)
                {
                    foreach (var propertyName in list.Skip(1))
                    {
                        tProperty = Expression.PropertyOrField(tProperty, propertyName);
                    }
                }

                expression = filter.ToExpressionEvaluate(tProperty, value);
            }
            else
            {
                tProperty = Expression.Property(param, property!.Name);
                expression = Expression.Equal(tProperty, Expression.Constant(value));
            }

            expressionBody = Expression.And(expressionBody, expression);
        }

        //ex: t => ((t.Name == "nah") && (t.Role.Name == "admin"))
        var lambda = Expression.Lambda<Func<TModel, bool>>(expressionBody, param);
        Console.WriteLine(lambda);
        return lambda;
    }
}