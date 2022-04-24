using CrudApiTemplate.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.View;

namespace WebApplication1.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public override IQueryable<User> WithAllData()
    {
        return Context.Set<User>()
            .AsQueryable()
            .Include(u => u.Role)
            .Include(u => u.Profiles);
    }

    public IEnumerable<UserView> Test()
    {
        var userViews = Test<UserView>(u => true, u => u.Id).ToList();
        return userViews;
    }
}