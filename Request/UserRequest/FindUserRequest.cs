using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using WebApplication1.Models;

namespace WebApplication1.Request.UserRequest;

public class FindUserRequest : IFindRequest<User>
{
    [Equal(target:"UserName")]
    public string? UserName { set; get; }

    [Equal]
    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int Status { get; set; } = 1;

    [Equal("Role.Name")]
    public string? RoleName { get; set; }
}