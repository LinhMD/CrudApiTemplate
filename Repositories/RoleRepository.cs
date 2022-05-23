using CrudApiTemplate.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class RoleRepository : Repository<Role>
{
    public RoleRepository(DataContext context) : base(context)
    {
    }

    public override IQueryable<Role> WithAllData()
    {
        return this.Models.AsQueryable();
    }
}