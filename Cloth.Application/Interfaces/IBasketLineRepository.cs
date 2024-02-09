using Cloth.Domain.Entities;
using Persistence.Abstractions.Interfaces;

namespace Cloth.Application.Interfaces;

public interface IBasketLineRepository : IGenericRepository<BasketLine>
{
    Task<Basket> GetBasketByUserIdAsync(Guid id);
}
