using System.Linq.Expressions;
using CrudApiTemplate.Request;

namespace CrudApiTemplate.Utilities;

public static class QueryableExtensions
{

    public static IQueryable<TModel> OrderByRequest<TModel>(this IQueryable<TModel> models, IOrderRequest<TModel> orderRequest)
        where TModel : class
    {
        if (orderRequest.OrderModels.Count == 0) return models;

        var firstSort = orderRequest.OrderModels[0];
        var sortModels = Order(models, firstSort);

        foreach (var sort in orderRequest.OrderModels)
        {
            sortModels = ThenOrder(sortModels, sort);
        }

        return sortModels;
    }

    public static IOrderedQueryable<TModel> Order<TModel, TKey>(IQueryable<TModel> models, bool isAscending,ParameterExpression para, Expression member) where TModel: class
    {
        var orderExpression = Expression.Lambda<Func<TModel, TKey>>(member, para);
        var sortModels = isAscending
            ? models.OrderBy(orderExpression)
            : models.OrderByDescending(orderExpression);
        return sortModels;
    }
    public static IOrderedQueryable<TModel> ThenOrder<TModel, TKey>(IOrderedQueryable<TModel> models, bool isAscending,ParameterExpression para, Expression member) where TModel: class
    {
        var orderExpression = Expression.Lambda<Func<TModel, TKey>>(member, para);
        var sortModels = isAscending
            ? models.ThenBy(orderExpression)
            : models.ThenByDescending(orderExpression);
        return sortModels;
    }

    //It's fucked but fuk it
    //https://stackoverflow.com/questions/32146571/expression-of-type-system-int64-cannot-be-used-for-return-type-system-object
    public static IOrderedQueryable<TModel> Order<TModel>(IQueryable<TModel> models, OrderModel<TModel> orderModel)
        where TModel : class
    {
        var para = Expression.Parameter(typeof(TModel), typeof(TModel).Name.ToLower());
        var member = Expression.Property(para, orderModel.PropertyName);

        //object type
        if (member.Type == typeof(object))
        {
            return Order<TModel, object>(models, orderModel.IsAscending, para, member);
        }

        //string type
        if (member.Type == typeof(string))
        {
            return Order<TModel, string>(models, orderModel.IsAscending, para, member);
        }

        //Integer types:
        if (member.Type == typeof(int))
        {
            return Order<TModel, int>(models, orderModel.IsAscending, para, member);
        }
        if(member.Type == typeof(long))
        {
            return Order<TModel, long>(models, orderModel.IsAscending, para, member);
        }
        if(member.Type == typeof(byte))
        {
            return Order<TModel, byte>(models, orderModel.IsAscending, para, member);
        }

        //Floating-point numeric types
        if(member.Type == typeof(double))
        {
            return Order<TModel, double>(models, orderModel.IsAscending, para, member);
        }
        if(member.Type == typeof(float))
        {
            return Order<TModel, float>(models, orderModel.IsAscending, para, member);
        }
        if(member.Type == typeof(decimal))
        {
            return Order<TModel, decimal>(models, orderModel.IsAscending, para, member);
        }

        //boolean type
        if(member.Type == typeof(bool))
        {
            return Order<TModel, bool>(models, orderModel.IsAscending, para, member);
        }

        //char type
        if(member.Type == typeof(char))
        {
            return Order<TModel, char>(models, orderModel.IsAscending, para, member);
        }
        
        throw new Exception($"Unsupported type {member.Type}");
    }

    public static IOrderedQueryable<TModel> ThenOrder<TModel>(IOrderedQueryable<TModel> models, OrderModel<TModel> orderModel)
        where TModel : class
    {
        var para = Expression.Parameter(typeof(TModel), typeof(TModel).Name.ToLower());
        var member = Expression.Property(para, orderModel.PropertyName);

        //object type
        if (member.Type == typeof(object))
        {
            return ThenOrder<TModel, object>(models, orderModel.IsAscending, para, member);
        }

        //string type
        if (member.Type == typeof(string))
        {
            return ThenOrder<TModel, string>(models, orderModel.IsAscending, para, member);
        }
        //Integer types:
        if (member.Type == typeof(int))
        {
            return ThenOrder<TModel, int>(models, orderModel.IsAscending, para, member);
        }

        if(member.Type == typeof(long))
        {
            return ThenOrder<TModel, long>(models, orderModel.IsAscending, para, member);
        }

        if(member.Type == typeof(byte))
        {
            return ThenOrder<TModel, byte>(models, orderModel.IsAscending, para, member);
        }

        //Floating-point numeric types
        if(member.Type == typeof(double))
        {
            return ThenOrder<TModel, double>(models, orderModel.IsAscending, para, member);
        }

        if(member.Type == typeof(float))
        {
            return ThenOrder<TModel, float>(models, orderModel.IsAscending, para, member);
        }

        if(member.Type == typeof(decimal))
        {
            return ThenOrder<TModel, decimal>(models, orderModel.IsAscending, para, member);
        }

        //boolean type
        if(member.Type == typeof(bool))
        {
            return ThenOrder<TModel, bool>(models, orderModel.IsAscending, para, member);
        }

        //char type
        if(member.Type == typeof(char))
        {
            return ThenOrder<TModel, char>(models, orderModel.IsAscending, para, member);
        }

        throw new Exception($"Unsupported type {member.Type}");
    }
}