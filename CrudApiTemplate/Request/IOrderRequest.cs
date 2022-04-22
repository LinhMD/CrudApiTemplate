using System.Linq.Expressions;

namespace CrudApiTemplate.Request;

public interface IOrderRequest<TModel> : IFindRequest<TModel> where TModel: class
{
    PagingRequest GetPaging();
    Expression<Func<TModel , object>> ToOrderBy();

}