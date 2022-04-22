using CrudApiTemplate.Attributes;
using CrudApiTemplate.View;
using WebApplication1.Models;

namespace WebApplication1.View;

public class RoleView : IView<Role>
{
    public RoleView()
    {
    }

    public RoleView(Role role)
    {
        Name = role.Name ?? string.Empty;
    }

    public string Name { get; set; } = string.Empty;

}