using Microsoft.AspNetCore.Mvc;
using WebApplication1.Request.UserRequest;
using WebApplication1.Services;
using WebApplication1.View;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;
    private readonly ILogger<UserController> _logger;
    public UserController(UserService service, ILogger<UserController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult FindUser(FindUserRequest request)
    {
        var begin = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        var users = _service.Find(request);
        _logger.Log(LogLevel.Information, "time:" + (DateTimeOffset.Now.ToUnixTimeMilliseconds() - begin));
        return Ok(users);
    }

    [HttpPost("2")]
    public IActionResult FindUser2(FindUserRequest2 request)
    {
        var begin = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        var users = _service.Find(request);
        _logger.Log(LogLevel.Information, "time:" + (DateTimeOffset.Now.ToUnixTimeMilliseconds() - begin));
        return Ok(users);
    }

    [HttpPost("3")]
    public IActionResult FindUser3(FindUserRequest3 request)
    {
        var begin = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        var users = _service.Find(request);
        _logger.Log(LogLevel.Information, "time:" + (DateTimeOffset.Now.ToUnixTimeMilliseconds() - begin));
        return Ok(users);
    }
    [HttpGet]
    public IActionResult Test()
    {
        return Ok(_service.GetAll<UserView>());
    }

    [HttpGet("1")]
    public IActionResult nah()
    {
        return Ok(_service.GetAll<UserView>());
    }
}