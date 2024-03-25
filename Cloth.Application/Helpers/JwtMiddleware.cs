namespace Cloth.Application.Helpers;

using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Services;
using Cloth.Application.Models;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await attachUserToContext(context, unitOfWork, token);

        await _next(context);
    }

    private async Task attachUserToContext(HttpContext context, IUnitOfWork unitOfWork, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
            Guid userIdGuid = Guid.Parse(userId);
            //Attach user to context on successful JWT validation
            context.Items["User"] = await unitOfWork.Users.GetByIdAsync(userIdGuid);
        }
        catch
        {
            //Do nothing if JWT validation fails
            // user is not attached to context so the request won't have access to secure routes
        }
    }
}