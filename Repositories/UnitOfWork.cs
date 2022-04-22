using CrudApiTemplate.Repositories;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly DataContext DataContext;

    protected readonly Dictionary<Type, object> Repositories = new();

    public UnitOfWork(DataContext dataContext)
    {
        DataContext = dataContext;
        Users = new UserRepository(dataContext);
        Repositories[typeof(User)] = Users;
    }



    public IRepository<TModel> Repository<TModel>() where TModel : class
    {
        return (Repositories[typeof(TModel)] as IRepository<TModel>)!;
    }

    public IUserRepository Users { get; }

    public int Complete()
    {
        return DataContext.SaveChanges();
    }

    public virtual void Dispose()
    {
        DataContext.Dispose();
    }

}