using System.Linq.Expressions;
using CrudApiTemplate.Request;

namespace CrudApiTemplate.Utilities;

public class OrderRequest<TModel> : IOrderRequest<TModel> where TModel: class
{
    public IList<SortModel<TModel>> SortModels { get; set; }

    public PagingRequest PagingRequest { get; set; }

    public PagingRequest GetPaging()
    {
        return PagingRequest;
    }

    public Expression<Func<TModel, object>> ToOrderBy()
    {
        throw new NotImplementedException();
    }

    public IQueryable<TModel> Ordered(IQueryable<TModel> models)
    {
        if (SortModels.Count == 0) return models;

        var first = SortModels[0];
        if (first.IsAscending)
        {
        }
        foreach (var sortModel in SortModels)
        {
            if (sortModel.IsAscending)
            {

            }
            else
            {

            }
        }

        return null;
    }
}