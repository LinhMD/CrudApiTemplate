using System.Linq.Expressions;
using CrudApiTemplate.View;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CrudApiTemplate.Repositories;

public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
{

    protected readonly DbContext Context;
    protected readonly DbSet<TModel> Models;

    protected Repository(DbContext context)
    {
        Context = context;
        Models = context.Set<TModel>();
    }

    public TModel? Get(int id)
    {
        return Context.Set<TModel>().Find(id);
    }

    public TView? Get<TView>(int id) where TView : class, IView<TModel>, new()
    {
        return Models.Find(id)?.Adapt<TView>();
    }

    public TModel Add(TModel model)
    {
        Models.Add(model);
        Context.SaveChanges();
        Context.Entry(model).GetDatabaseValues();
        return model;
    }

    public void AddAll(IEnumerable<TModel> models)
    {
        Models.AddRange(models);
        Context.SaveChanges();
    }

    public void Remove(TModel model)
    {
        Models.Remove(model);

        Context.SaveChanges();
    }

    public void RemoveAll(IEnumerable<TModel> models)
    {
        Models.RemoveRange(models);
        Context.SaveChanges();
    }

    public IQueryable<TView> Test<TView>(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, object>> orderBy)
        where TView : class, IView<TModel>, new()
    {
        IQueryable<TView> models = new TView().DynamicInclude(Models)
            .Where(predicate)
            .OrderBy(orderBy)
            .ProjectToType<TView>();

        return models;
    }

    public IEnumerable<TModel> GetAll()
    {
        return WithAllData().ToList();
    }

    public IEnumerable<TView> GetAll<TView>() where TView : class, IView<TModel>, new()
    {
        return new TView().DynamicInclude(Models)
            .ProjectToType<TView>()
            .ToList();
    }

    public IEnumerable<TModel> GetAllPaging(out int total, int page = 1, int pageSize = 20)
    {
        total = WithAllData().Count();
        return WithAllData()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public IEnumerable<TView> GetAllPaging<TView>(out int total, int page = 1, int pageSize = 20)
        where TView : class, IView<TModel>, new()
    {

        total = Models.Count();
        return new TView().DynamicInclude(Models)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ProjectToType<TView>().ToList();
    }

    public IEnumerable<TModel> GetAllOrderedPaging(Expression<Func<TModel, object>> orderBy, out int total, int page = 1, int pageSize = 20)
    {
        var views = WithAllData().OrderBy(orderBy);

        total = views.Count();

        return views.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public IEnumerable<TView> GetAllOrderedPaging<TView>(Expression<Func<TModel, object>> orderBy, out int total, int page = 1, int pageSize = 20)
        where TView : class, IView<TModel>, new()
    {
        var views = new TView().DynamicInclude(Models)
            .OrderBy(orderBy)
            .ProjectToType<TView>();

        total = views.Count();

        return views.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate)
    {
        return WithAllData()
            .Where(predicate)
            .ToList();

    }

    public IEnumerable<TView> Find<TView>(Expression<Func<TModel, bool>> predicate)
        where TView : class, IView<TModel>, new()
    {
        return new TView()
            .DynamicInclude(Models)
            .Where(predicate)
            .ProjectToType<TView>()
            .ToList();
    }

    public IEnumerable<TModel> FindOrderedPaging(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, object>> orderBy, out int total, int page = 1, int pageSize = 20)
    {
        var views = WithAllData()
            .Where(predicate)
            .OrderBy(orderBy);
        total = views.Count();

        return views.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public IEnumerable<TView> FindOrderedPaging<TView>(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, object>> orderBy, out int total, int page = 1, int pageSize = 20)
        where TView : class, IView<TModel>, new()
    {
        var views = new TView().DynamicInclude(Models)
            .Where(predicate)
            .OrderBy(orderBy)
            .ProjectToType<TView>();
        total = views.Count();

        return views.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }

    public void Commit()
    {
        Context.SaveChanges();
    }


    public abstract IQueryable<TModel> WithAllData();

}