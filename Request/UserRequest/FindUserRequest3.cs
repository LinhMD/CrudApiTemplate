using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using WebApplication1.Models;

namespace WebApplication1.Request.UserRequest;

public class FindUserRequest3 : IFindRequest<User>
{
    [LessThan("Id")]
    public int? IdLessThan { get; set; }

    [BiggerThan("Role.Id")]
    public int? RoleIdGreaterThan { get; set; }

    [Contain("UserName")]
    public string? NameContain { get; set; }

    //Ids.Contains(User.Id)
    [In("Id")]
    public List<int>? Ids { get; set; }

    //User.Profiles.Any(Profile => Profile.Gender == ProfileGender)
    [Any("Profiles","Gender", typeof(EqualAttribute))]
    public bool? ProfileGender { get; set; }

    [Any("Profiles","Id", typeof(EqualAttribute))]
    public int? ProfileId { get; set; }

}