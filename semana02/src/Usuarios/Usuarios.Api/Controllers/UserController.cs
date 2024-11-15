using Microsoft.AspNetCore.Mvc;
using Usuarios.Api.Models;
using Usuarios.Api.Service;

namespace Usuarios.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return user is not null ? Ok(user) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserModel user)
    {
        var newUser = await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
    }
}