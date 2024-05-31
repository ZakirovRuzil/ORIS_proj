using Microsoft.AspNetCore.Identity;

namespace Core.DTOs;

public class UserSignInResultDTO
{
    public UserSignInResultDTO(string jwtToken, Guid userId, SignInResult result)
    {
        JwtToken = jwtToken;
        UserId = userId;
        Result = result;
    }

    /// <summary>
    /// Jwt
    /// </summary>
    public string JwtToken { get; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Результат входа
    /// </summary>
    public SignInResult Result { get; }
}