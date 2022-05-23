using CrudApiTemplate.Repositories;
using CrudApiTemplate.Utilities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

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

    public List<User> test()
    {
        var request = new OrderRequest<User>();

        request.OrderModels.Add(new OrderModel<User>()
        {
            IsAscending = true,
            PropertyName = nameof(User.PhoneNumber)
        });


        return Models.AsQueryable().OrderByRequest(request).ToList();
    }

}