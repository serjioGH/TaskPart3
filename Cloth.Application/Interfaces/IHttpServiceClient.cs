namespace Cloth.Application.Interfaces;
using Cloth.Domain.Entities;

public interface IHttpServiceClient
{
    Task<IEnumerable<Cloth>> GetClothsAsync();
}