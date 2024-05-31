using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services;

/// <inheritdoc />
public class JwtService: IJwtService
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="configuration">Конфигурация проекта</param>
    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    /// <inheritdoc />
    public string GenerateJwt(Guid userId, string? email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityKey = Encoding.UTF8.GetBytes(
            _configuration["JwtSettings:SecretKey"]!);
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId.ToString()),
            new(ClaimTypes.Email, email ?? string.Empty)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _configuration["JwtSettings:Audience"],
            Issuer = _configuration["JwtSettings:Issuer"],
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(
                _configuration["JwtSettings:AccessTokenLifetimeInMinutes"]!)),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(jwtSecurityKey),
                    SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}