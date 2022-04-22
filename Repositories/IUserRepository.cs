using CrudApiTemplate.Repositories;
using WebApplication1.Models;
using WebApplication1.View;

namespace WebApplication1.Repositories;

public interface IUserRepository : IRepository<User>
{
    public IEnumerable<UserView> Test();
}