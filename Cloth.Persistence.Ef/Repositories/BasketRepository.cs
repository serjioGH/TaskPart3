using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.Ef.Context;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Repositories;

namespace Cloth.Persistence.Ef.Repositories;

public class BasketRepository : GenericRepository<Basket>, IBasketRepository
{
    protected readonly ClothInventoryDbContext _dbContext;

    public BasketRepository(ClothInventoryDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Basket> GetBasketByUserIdAsync(Guid id)
    {
        try
        {
            var result = await _dbContext.Baskets
                .Include(b => b.BasketLines)
                .SingleAsync(o => o.UserId == id);
            return result;
        }
        catch (ArgumentNullException)
        {
            throw new ItemNotFoundException($"Basket of User ID {id} not found.");
        }
        catch (Exception ex)
        {
            throw new ItemNotFoundException($"Basket of User ID {id} not found.", ex);
        }
    }
}