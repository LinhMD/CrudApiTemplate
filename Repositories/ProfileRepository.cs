using CrudApiTemplate.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class ProfileRepository : Repository<Profile>
{
    public ProfileRepository(DbContext context) : base(context)
    {
    }
}