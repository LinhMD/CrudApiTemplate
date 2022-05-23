using CrudApiTemplate.Repositories;
using WebApplication1.Data;
using WebApplication1.Migrations;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class WebUow : UnitOfWork, IWebUow
{
    public WebUow(DataContext dataContext) : base(dataContext)
    {
        Users = new UserRepository(dataContext);
        Add(Users);
        Roles = new RoleRepository(dataContext);
        Add(Roles);
        Profiles = new ProfileRepository(dataContext);
    }

    public IUserRepository Users { get; }

    public IRepository<Role> Roles { get; }

    public IRepository<Profile> Profiles { get; }
}