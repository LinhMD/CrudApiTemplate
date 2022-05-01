using CrudApiTemplate.Services;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class UserService : ServiceCrud<User>
{
    private readonly IUserRepository _userRepository;
    public UserService(IUnitOfWork work) : base(work.Users)
    {
        _userRepository = work.Users;
    }

}