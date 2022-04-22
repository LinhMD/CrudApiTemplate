using CrudApiTemplate.Services;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.View;

namespace WebApplication1.Services;

public class UserService : ServiceCrud<User>
{
    private readonly IUserRepository _userRepository;
    public UserService(IUnitOfWork work) : base(work.Repository<User>()!)
    {
        _userRepository = (work.Repository<User>() as IUserRepository)!;
    }

    public IEnumerable<UserView> Test()
    {
        return _userRepository.Test();
    }
}