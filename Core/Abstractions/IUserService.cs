using Core.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Core.Abstractions;

public interface IUserService
{
    public Task<IdentityResult> RegisterUserAsync(UserRegisterDTO userRegisterDto);

    public Task<UserSignInResultDTO> SignIn(UserSignInDTO userSignInDto);
}