using System.ComponentModel.DataAnnotations;
using Core.Abstractions;
using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtService _jwtService;
    private readonly SignInManager<User> _signInManager;

    public UserService(UserManager<User> userManager, IJwtService jwtService, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterUserAsync(UserRegisterDTO userRegisterDto)
    {
        var isUserExist = await _userManager.FindByEmailAsync(userRegisterDto.Email);
        if (isUserExist != null)
            throw new ValidationException("Пользователь с текущей почтой уже существует");

        var user = new User()
        {
            UserName = userRegisterDto.Email,
            FirstName = userRegisterDto.FirstName,
            LastName = userRegisterDto.LastName,
            Age = userRegisterDto.Age,
            Email = userRegisterDto.Email,
            PhoneNumber = userRegisterDto.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

        return result;
    }

    public async Task<UserSignInResultDTO> SignIn(UserSignInDTO userSignInDto)
    {
        var user = await _userManager.FindByEmailAsync(userSignInDto.Email);

        if (user == null)
            throw new ValidationException("Не удалось найти пользователя");

        var result = await _signInManager.PasswordSignInAsync(user, userSignInDto.Password, false, false);
        
        string token = null!;
        
        if (result.Succeeded)
        {
            token = _jwtService.GenerateJwt(user.Id, user.Email);
        }
        else
        {
            throw new ValidationException("Авторизация не прошла");
        }

        return new UserSignInResultDTO(token, user.Id, result);
    }
}