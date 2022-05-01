using Mapster;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;
using WebApplication1.View;

var builder = WebApplication.CreateBuilder(args);

TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

// Add services to the container

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("BadgeEntry", policy =>
        policy.RequireAssertion(context =>
        {
            object? value = null;
            if (context.Resource is HttpContext httpContext)
            {
                value = httpContext.GetRouteValue("key");
            }


            return context.User.HasClaim(c =>
                (c.Type == "BadgeId" || c.Type == "TemporaryBadgeId")
                && c.Issuer == "https://microsoftsecurity");
        }));
});



TypeAdapterConfig<User, UserView>.NewConfig().Map(view => view.RoleSetting, user => user.Role.Setting);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();