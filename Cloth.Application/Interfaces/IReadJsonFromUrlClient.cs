namespace Cloth.Application.Interfaces;
using Cloth.Domain.Entities;

public interface IReadJsonFromUrlClient
{
    Task<IEnumerable<Cloth>> GetClothsAsync(string url);
}