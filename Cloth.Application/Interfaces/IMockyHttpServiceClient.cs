namespace Cloth.Application.Interfaces;

using Cloth.Domain.Entities;

public interface IMockyHttpServiceClient
{
    Task<IEnumerable<Cloth>> GetClothsAsync();
}