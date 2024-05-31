using Core.Abstractions;
using Core.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eventify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("signIn")]
    public async Task<UserSignInResultDTO> SignInAsync(
        [FromBody] UserSignInDTO userSignInDto)
        => await _userService.SignIn(userSignInDto);    

    [HttpPost("register")]
    public async Task<IdentityResult> RegisterAsync(
        [FromBody] UserRegisterDTO userRegisterDto)
        => await _userService.RegisterUserAsync(userRegisterDto);    
}