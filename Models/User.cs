using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string UserName { set; get; }

    public string? Email { get; set; }

    public int RoleId { get; set; }

    public Role Role { get; set; }

    [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Must be phone number")]
    public string? PhoneNumber { get; set; }

    public int Status { get; set; } = 1;

    public string? AvatarLink { get; set; }

    public IList<Profile> Profiles { get; set; } = new List<Profile>();


}