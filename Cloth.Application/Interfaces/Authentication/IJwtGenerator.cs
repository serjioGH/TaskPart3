namespace Cloth.Application.Interfaces.Authentication;

using Cloth.Domain.Entities;
using System.Security.Claims;

public interface IJwtGenerator
{
    string GenerateToken(User user, string userRole);

    string GenerateRefreshToken(int size);
}