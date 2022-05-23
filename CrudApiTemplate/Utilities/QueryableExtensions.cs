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

    //It's fucked but fuk it
    //https://stackoverflow.com/questions/32146571/expression-of-type-system-int64-cannot-be-used-for-return-type-system-object
    public static IOrderedQueryable<TModel> Order<TModel>(IQueryable<TModel> models, OrderModel<TModel> orderModel)
        where TModel : class
    {
        var para = Expression.Parameter(typeof(TModel), typeof(TModel).Name.ToLower());
        var member = Expression.Property(para, orderModel.PropertyName);
        IOrderedQueryable<TModel> sortModels;

        //object type
        if (member.Type == typeof(object))
        {
            Expression<Func<TModel, object>> orderExpression = Expression.Lambda<Func<TModel, object>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }

        //string type
        if (member.Type == typeof(string))
        {
            Expression<Func<TModel, string>> orderExpression = Expression.Lambda<Func<TModel, string>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }
        //Integer types:
        if (member.Type == typeof(int))
        {
            Expression<Func<TModel, int>> orderExpression = Expression.Lambda<Func<TModel, int>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }

        if(member.Type == typeof(long))
        {
            Expression<Func<TModel, long>> orderExpression = Expression.Lambda<Func<TModel, long>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }

        if(member.Type == typeof(byte))
        {
            Expression<Func<TModel, byte>> orderExpression = Expression.Lambda<Func<TModel, byte>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }

        //Floating-point numeric types
        if(member.Type == typeof(double))
        {
            Expression<Func<TModel, double>> orderExpression = Expression.Lambda<Func<TModel, double>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }

        if(member.Type == typeof(float))
        {
            Expression<Func<TModel, float>> orderExpression = Expression.Lambda<Func<TModel, float>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }

        if(member.Type == typeof(decimal))
        {
            Expression<Func<TModel, decimal>> orderExpression = Expression.Lambda<Func<TModel, decimal>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }

        //boolean type
        if(member.Type == typeof(bool))
        {
            Expression<Func<TModel, bool>> orderExpression = Expression.Lambda<Func<TModel, bool>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }

        //char type
        if(member.Type == typeof(char))
        {
            Expression<Func<TModel, char>> orderExpression = Expression.Lambda<Func<TModel, char>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.OrderBy(orderExpression)
                : models.OrderByDescending(orderExpression);
            return sortModels;
        }


        throw new Exception($"Unsupported type {member.Type}");
    }

    public static IOrderedQueryable<TModel> ThenOrder<TModel>(IOrderedQueryable<TModel> models, OrderModel<TModel> orderModel)
        where TModel : class
    {
        var para = Expression.Parameter(typeof(TModel), typeof(TModel).Name.ToLower());
        var member = Expression.Property(para, orderModel.PropertyName);
        IOrderedQueryable<TModel> sortModels;

        //object type
        if (member.Type == typeof(object))
        {
            Expression<Func<TModel, object>> orderExpression = Expression.Lambda<Func<TModel, object>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }

        //string type
        if (member.Type == typeof(string))
        {
            Expression<Func<TModel, string>> orderExpression = Expression.Lambda<Func<TModel, string>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }
        //Integer types:
        if (member.Type == typeof(int))
        {
            Expression<Func<TModel, int>> orderExpression = Expression.Lambda<Func<TModel, int>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }

        if(member.Type == typeof(long))
        {
            Expression<Func<TModel, long>> orderExpression = Expression.Lambda<Func<TModel, long>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }

        if(member.Type == typeof(byte))
        {
            Expression<Func<TModel, byte>> orderExpression = Expression.Lambda<Func<TModel, byte>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }

        //Floating-point numeric types
        if(member.Type == typeof(double))
        {
            Expression<Func<TModel, double>> orderExpression = Expression.Lambda<Func<TModel, double>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }

        if(member.Type == typeof(float))
        {
            Expression<Func<TModel, float>> orderExpression = Expression.Lambda<Func<TModel, float>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }

        if(member.Type == typeof(decimal))
        {
            Expression<Func<TModel, decimal>> orderExpression = Expression.Lambda<Func<TModel, decimal>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }

        //boolean type
        if(member.Type == typeof(bool))
        {
            Expression<Func<TModel, bool>> orderExpression = Expression.Lambda<Func<TModel, bool>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }

        //char type
        if(member.Type == typeof(char))
        {
            Expression<Func<TModel, char>> orderExpression = Expression.Lambda<Func<TModel, char>>(member, para);
            sortModels = orderModel.IsAscending
                ? models.ThenBy(orderExpression)
                : models.ThenByDescending(orderExpression);
            return sortModels;
        }


        throw new Exception($"Unsupported type {member.Type}");
    }
}