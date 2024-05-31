using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Eventify.Attributes;

public class AuthAttribute: AuthorizeAttribute
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="policy">Политики</param>
    public AuthAttribute(string policy)
        : base(policy)
    {
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
    }
}