namespace Core.Abstractions;

public interface IJwtService
{
    public string GenerateJwt(Guid userId, string? email);
}