namespace Cloth.Application.Helpers;

using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Services;
using Cloth.Application.Models;
using Cloth.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly AppSettings _appSettings;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
    {
        _appSettings = appSettings.Value;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
        var user = await _unitOfWork.Users.GetUser(model.Password, model.Username);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = await generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    private async Task<string> generateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() =>
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        });

        return tokenHandler.WriteToken(token);
    }
}