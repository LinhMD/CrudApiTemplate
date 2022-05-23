using CrudApiTemplate.Services;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class UserService : ServiceCrud<User>
{
    private IUserRepository _repository;
    public UserService(IWebUow work) : base(work.Users, work)
    {
        _repository = work.Users;
    }

    public List<User> test()
    {
        return _repository.test();
    }

}