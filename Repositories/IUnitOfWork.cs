
using CrudApiTemplate.Repositories;

namespace WebApplication1.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IRepository<TModel>? Repository<TModel>() where TModel : class;

    public IUserRepository Users { get; }
    int Complete();
}