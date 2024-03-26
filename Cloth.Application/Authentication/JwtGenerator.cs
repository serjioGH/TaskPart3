namespace Cloth.Application.Authentication;

using Cloth.Application.Identity;
using Cloth.Application.Interfaces.Authentication;
using Cloth.Application.Models;
using Cloth.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class JwtGenerator : IJwtGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtGenerator(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateRefreshToken(int size = 32)
    {
        using var rng = RandomNumberGenerator.Create();
        var randomNumber = new byte[size];
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber)
            // Remove any non-alphanumeric characters
            .Replace("/", "")
            .Replace("+", "")
            .Replace("=", "")
            // Trim to the desired length
            .Substring(0, size);
    }

    public string GenerateToken(User user, string role)
    {
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(IdentityData.AdminUserClaim, role)
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}