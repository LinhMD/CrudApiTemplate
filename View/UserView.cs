using CrudApiTemplate.Attributes;
using CrudApiTemplate.View;
using Mapster;
using WebApplication1.Models;

namespace WebApplication1.View;

[Include("Role")]
[Include("Profiles")]
public class UserView :  IView<User>
{
    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public RoleView Role { get; set; } = new();

    public string RoleName { get; set; } = string.Empty;

    public string RoleSetting { get; set; } = string.Empty;

    public int Status { get; set; } = 1;

    public IList<ProfileView> Profiles { get; set; } = new List<ProfileView>();

    public void SetupMapping()
    {
        TypeAdapterConfig<User, UserView>.NewConfig().Map(view => view.RoleSetting, user => user.Role.Setting);
    }
}