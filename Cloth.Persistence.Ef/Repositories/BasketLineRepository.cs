namespace Cloth.Persistence.Ef.Repositories;

using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.Ef.Context;
using global::Persistence.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class BasketLineRepository : GenericRepository<BasketLine>, IBasketLineRepository
{
    protected readonly ClothInventoryDbContext _dbContext;

    public BasketLineRepository(ClothInventoryDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteAll(Guid basketId)
    {
        var basketLinesToRemove = await _dbContext.BasketLines
                   .Where(bl => bl.BasketId == basketId)
                   .ToListAsync();

        _dbContext.BasketLines.RemoveRange(basketLinesToRemove);
    }

    public async Task<BasketLine> GetBasketLine(Guid basketId)
    {
        try
        {
            var basketLine = await _dbContext.BasketLines
                .Include(b => b.Basket)
                .Include(b => b.Cloth)
                .Include(b => b.Size)
                .SingleAsync(bl => bl.Id == basketId);
            return basketLine;
        }
        catch (ArgumentNullException ex)
        {
            throw new ItemNotFoundException($"Retrieving Basket resulted in an error.", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new ItemNotFoundException($"Retrieving Basket resulted in an error.", ex);
        }
        catch (Exception)
        {
            throw new ItemNotFoundException($"Retrieving Basket resulted in an error.");
        }
    }
}