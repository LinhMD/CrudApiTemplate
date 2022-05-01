using System.Linq.Expressions;
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

    [Contain("Role.Name")]
    [Contain("UserName")]
    public string? NameContain { get; set; }



    [In("Id")]
    public List<int>? Ids { get; set; }

    //User.Profiles.Any(Profile => Profile.Gender == ProfileGender)
    [Any("Profiles","Gender", typeof(EqualAttribute), typeof(Profile))]
    public bool ProfileGender { get; set; }

    /*public Expression<Func<User, bool>> ToPredicate()
    {
        return u => u.Profiles.Any(p => p.Gender == ProfileGender);
    }*/
}