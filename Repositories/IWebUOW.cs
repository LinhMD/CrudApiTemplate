using CrudApiTemplate.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IWebUow : IUnitOfWork
{
    IUserRepository Users { get; }

    IRepository<Role> Roles { get; }

    IRepository<Profile> Profiles { get; }
}