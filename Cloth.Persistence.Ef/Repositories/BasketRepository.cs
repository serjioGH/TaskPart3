using Cloth.Application.Interfaces;
using Cloth.Domain.Entities;
using Cloth.Persistence.Ef.Context;
using Persistence.Abstractions.Repositories;

namespace Cloth.Persistence.Ef.Repositories;

public class BasketRepository : GenericRepository<Basket>, IBasketRepository
{
    protected readonly ClothInventoryDbContext _dbContext;
    public BasketRepository(ClothInventoryDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Basket> GetBasketByUserIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
