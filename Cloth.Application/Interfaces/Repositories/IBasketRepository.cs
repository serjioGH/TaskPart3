using Cloth.Domain.Entities;
using Persistence.Abstractions.Interfaces;

namespace Cloth.Application.Interfaces.Repositories;

public interface IBasketRepository : IGenericRepository<Basket>
{
    Task<Basket> GetBasketByUserIdAsync(Guid id, CancellationToken cancellationToken = default);
}