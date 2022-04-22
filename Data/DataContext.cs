using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class DataContext : DbContext
{
    private readonly IConfiguration _config;
    public DataContext(IConfiguration configuration)
    {
        _config = configuration;
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Role { get; set; }

    public DbSet<Profile> Profiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config["ConnectionStrings:LocalHost"] ?? "Server=desktop-8m2nj75;Database=Astrology;User Id=sa;Password=123456;");
    }
}