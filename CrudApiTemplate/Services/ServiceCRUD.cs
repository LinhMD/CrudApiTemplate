using CrudApiTemplate.CustomException;
using CrudApiTemplate.Repositories;
using CrudApiTemplate.Request;
using CrudApiTemplate.Utilities;
using CrudApiTemplate.View;

namespace CrudApiTemplate.Services;

public abstract class ServiceCrud<TModel> : IServiceCrud<TModel> where TModel : class
{
    protected readonly IRepository<TModel> Repository;

    public ServiceCrud(IRepository<TModel> repository)
    {
        Repository = repository;
    }



    public TModel Create(ICreateRequest<TModel> createRequest)
    {
        TModel model = createRequest.CreateNew();

        Validation.Validate(model);

        try
        {
            model = Repository.Add(model);
        }
        catch(Exception ex)
        {
            throw new DbQueryException(ex);
        }


        return model;
    }

    public TModel Delete(int id)
    {
        TModel model = Get(id);

        try
        {
            Repository.Remove(model);
        }
        catch (Exception ex)
        {
            throw new DbQueryException(ex);
        }

        return model;
    }

    public TView Get<TView>(int id) where TView : class, IView<TModel>, new()
    {
        TView? model = Repository.Get<TView>(id);

        if (model == null) throw new ModelNotFoundException<TModel>(typeof(TModel).Name);

        return model;
    }



    public IEnumerable<TModel> Find(IFindRequest<TModel> findRequest)
    {
        return Repository.Find(findRequest.ToPredicate());
    }

    public IEnumerable<TView> Find<TView>(IFindRequest<TModel> findRequest) where TView : class, IView<TModel>, new()
    {
        return Repository.Find<TView>(findRequest.ToPredicate());
    }

    public (IEnumerable<TModel> models, int total) FindSortedPaging(IOrderRequest<TModel> orderRequest)
    {
        PagingRequest paging = orderRequest.GetPaging();
        IEnumerable<TModel> models = Repository.FindOrderedPaging(orderRequest.ToPredicate(), orderRequest.ToOrderBy(), out int total, paging.Page, paging.PageSize);
        return (models, total);
    }

    public (IEnumerable<TView> models, int total) FindSortedPaging<TView>(IOrderRequest<TModel> orderRequest) where TView : class, IView<TModel>, new()
    {
        PagingRequest paging = orderRequest.GetPaging();
        IEnumerable<TView> models = Repository.FindOrderedPaging<TView>(orderRequest.ToPredicate(), orderRequest.ToOrderBy(), out int total, paging.Page, paging.PageSize);
        return (models, total);
    }
    public TModel Get(int id)
    {
        TModel? model = Repository.Get(id);

        if (model == null) throw new ModelNotFoundException<TModel>(typeof(TModel).Name);

        return model;
    }

    public IEnumerable<TModel> GetAll()
    {
        return Repository.GetAll();
    }

    public IEnumerable<TView> GetAll<TView>() where TView : class, IView<TModel>, new()
    {
        return Repository.GetAll<TView>();
    }

    public TModel Update(int id, IUpdateRequest<TModel> updateRequest)
    {
        var model = Get(id);

        updateRequest.UpdateModel(ref model);

        try
        {
            Repository.Commit();
        }
        catch(Exception ex)
        {
            throw new DbQueryException(ex);
        }

        return model;
    }
}