using Cloth.Domain.Entities;
using Persistence.Abstractions.Interfaces;

namespace Cloth.Application.Interfaces.Repositories;

public interface IBasketLineRepository : IGenericRepository<BasketLine>
{
    Task DeleteAll(Guid basketId);

    Task<BasketLine> GetBasketLine(Guid basketLineId);
}