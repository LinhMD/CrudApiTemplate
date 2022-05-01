using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using WebApplication1.Models;

namespace WebApplication1.Request.UserRequest;

public class FindUserRequest2 : IFindRequest<User>
{
    [Equal]
    public int Id { get; set; }

    public string? PhoneNumber { get; set; }

    [Equal("Status")]
    public int  Status { get; } = 1;

    public string? AvatarLink { get; set; }
}