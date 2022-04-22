using System.Linq.Expressions;
using CrudApiTemplate.View;

namespace CrudApiTemplate.Repositories;

public interface IRepository<TModel> where TModel : class
{
    TModel? Get(int id);

    TView? Get<TView>(int id) where TView :class, IView<TModel>,  new();

    IEnumerable<TModel> GetAll();

    IEnumerable<TView> GetAll<TView>() where TView : class, IView<TModel>, new();


    IEnumerable<TModel> GetAllPaging(out int total, int page = 1, int pageSize = 20);

    IEnumerable<TView> GetAllPaging<TView>(out int total, int page = 1, int pageSize = 20) where TView : class, IView<TModel>, new();

    IEnumerable<TModel> GetAllOrderedPaging(Expression<Func<TModel, object>> orderBy, out int total, int page = 1, int pageSize = 20);

    IEnumerable<TView> GetAllOrderedPaging<TView>(Expression<Func<TModel, object>> orderBy, out int total, int page = 1, int pageSize = 20) where TView : class, IView<TModel>, new();

    IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate);

    IEnumerable<TView> Find<TView>(Expression<Func<TModel, bool>> predicate) where TView : class, IView<TModel>, new();

    IEnumerable<TModel> FindOrderedPaging(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, object>> orderBy, out int total, int page = 1, int pageSize = 20);

    IEnumerable<TView> FindOrderedPaging<TView>(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, object>> orderBy, out int total, int page = 1, int pageSize = 20) where TView : class, IView<TModel>, new();



    IQueryable<TModel> WithAllData();

    TModel Add(TModel model);
    void AddAll(IEnumerable<TModel> models);

    void Remove(TModel model);
    void RemoveAll(IEnumerable<TModel> models);

    public void Commit();
}