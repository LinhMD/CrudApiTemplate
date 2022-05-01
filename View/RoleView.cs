using CrudApiTemplate.Attributes;
using CrudApiTemplate.View;
using Mapster;
using WebApplication1.Models;

namespace WebApplication1.View;

public class RoleView : IView<Role>
{

    public string Name { get; set; } = string.Empty;

    public string Setting { get; set; } = string.Empty;


}