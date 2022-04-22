namespace WebApplication1.Models;

public class Profile
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? BirthPlace { get; set; }

    public string? ProfilePhoto { get; set; }

    public bool Gender { get; set; }
}