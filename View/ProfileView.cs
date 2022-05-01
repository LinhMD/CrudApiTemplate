using CrudApiTemplate.View;
using WebApplication1.Models;

namespace WebApplication1.View;

public class ProfileView : IView<Profile>
{
    public ProfileView()
    {
    }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public string BirthPlace { get; set; } = string.Empty;

    public string ProfilePhoto { get; set; } = string.Empty;

    public bool Gender { get; set; } = true;

}