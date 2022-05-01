using System.Linq.Expressions;
using System.Reflection;

namespace CrudApiTemplate.Attributes.Search;

public class AnyAttribute : FilterAttribute
{

    private FilterAttribute Filter { get; }

    private readonly Type _paraType;

    private readonly string _property;
    public AnyAttribute(string target, string property, Type filterType, Type paraType) : base(target)
    {

        if (!filterType.IsSubclassOf(typeof(FilterAttribute)))
            throw new Exception("Coding error of using AnyAttribute");

        Filter = (FilterAttribute?) Activator.CreateInstance(filterType, property) ?? new EqualAttribute(property);

        _paraType = paraType;
        _property = property;
    }
    public override Expression ToExpressionEvaluate(Expression parameter, object value)
    {
        //Profile
        var innerParameter = Expression.Parameter(_paraType, _paraType.Name);

        var members = _property.Split(".");
        var memberExpression = Expression.Property(innerParameter, members[0]);
        foreach (var member in members.Skip(1))
        {
            memberExpression = Expression.Property(innerParameter, member);
        }
        //Profile.Gender == true;
        var innerBody = Filter.ToExpressionEvaluate(Expression.Property(memberExpression, _property), value);
        //Profile => Profile.Gender == true
        var innerLambda = Expression.Lambda(innerBody, innerParameter);
        var anyMethod = typeof(Enumerable).GetMethods().Single(m => m.Name == "Any" && m.GetParameters().Length == 2);
        anyMethod = anyMethod.MakeGenericMethod(_paraType);
        //User.Profiles.Any(Profile => (Profile.Gender == True))
        return Expression.Call(null, anyMethod, parameter, innerLambda);
    }
}