namespace Cloth.Application.Interfaces.Services;

using Cloth.Application.Models;
using System.Threading.Tasks;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
}