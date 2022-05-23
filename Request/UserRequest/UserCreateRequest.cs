using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Attributes;
using CrudApiTemplate.Repositories;
using CrudApiTemplate.Request;
using Mapster;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Request.UserRequest;

public class UserCreateRequest : ICreateRequest<User>
{
    [Required]
    [MaxLength(255)]
    public string UserName { set; get; } = "User Name";

    public string? Email { get; set; }

    public int RoleId { get;  } = 1;

    [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Must be phone number")]
    public string? PhoneNumber { get; set; }

    public int Status { get;  } = 1;

    public string? AvatarLink { get; set; }

    public User CreateNew()
    {
        return this.Adapt<User>();
    }

    public User CreateNew(IUnitOfWork work)
    {
        var roles = work.Get<Role>();
        var role = roles.Get(this.RoleId);
        if (role == null) throw new ArgumentException($"Role Id {RoleId} not found!!!");


        return new User(){
            UserName = UserName,
            Email = Email,
            RoleId = RoleId,
            PhoneNumber = PhoneNumber,
            Status = Status,
            AvatarLink = AvatarLink
        };
    }
}