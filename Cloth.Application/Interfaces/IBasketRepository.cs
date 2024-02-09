using Cloth.Domain.Entities;
using Persistence.Abstractions.Interfaces;

namespace Cloth.Application.Interfaces;

public interface IBasketRepository : IGenericRepository<Basket>
{
    Task<Basket> GetBasketByUserIdAsync(Guid id);
}
