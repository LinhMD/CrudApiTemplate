using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using WebApplication1.Models;

namespace WebApplication1.Request.UserRequest;

public class FindUserRequest3 : IFindRequest<User>
{
    [LessThan("Id")]
    public int IdLessThan { get; set; }

    [BiggerThan("Role.Id")]
    public int RoleIdGreaterThan { get; set; }

    [Contain("UserName")]
    public string? NameContainString { get; set; }

    [In("Id")]
    public List<int>? Ids { get; set; }
}