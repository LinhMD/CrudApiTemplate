using CrudApiTemplate.Repositories;
using WebApplication1.Data;

namespace WebApplication1.Repositories;

public class WebUow : UnitOfWork, IWebUow
{
    public WebUow(DataContext dataContext) : base(dataContext)
    {
        Users = new UserRepository(dataContext);
        Add(Users);
    }

    public IUserRepository Users { get; }
}