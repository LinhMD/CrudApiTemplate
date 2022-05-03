using CrudApiTemplate.Repositories;

namespace WebApplication1.Repositories;

public interface IWebUow : IUnitOfWork
{
    IUserRepository Users { get; }
}