using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Repositories;
using Cloth.Persistence.PostgreSQL.Context;
using System.Data;

namespace Cloth.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClothInventoryDbContext _dbContext;
    private IDbTransaction _dbTransaction;
    public IClothRepository Cloths { get; }
    public ISizeRepository Sizes { get; }
    public IGroupRepository Groups { get; }
    public IBasketRepository Baskets { get; }
    public IBasketLineRepository BasketLines { get; }
    public IOrderRepository Orders { get; }
    public IClothSizeRepository ClothSizes { get; }

    public UnitOfWork(ClothInventoryDbContext dbContext, IDbTransaction dbTransaction, IClothRepository clothRepository,
        ISizeRepository sizes, IOrderRepository orders, IGroupRepository groups, IBasketRepository baskets, IBasketLineRepository basketLines, IClothSizeRepository clothSizes)
    {
        _dbContext = dbContext;
        _dbTransaction = dbTransaction;
        Cloths = clothRepository;
        Sizes = sizes;
        Orders = orders;
        Groups = groups;
        Baskets = baskets;
        BasketLines = basketLines;
        ClothSizes = clothSizes;
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _dbTransaction.Dispose();
        _dbContext.Dispose();
    }

    public void CommitTransaction()
    {
        try
        {
            _dbTransaction.Commit();
        }
        catch (Exception ex)
        {
            _dbTransaction.Rollback();
            throw new ApplicationException("An error occurred while committing changes.", ex);
        }
        finally
        {
            _dbTransaction.Dispose();
        }
    }

    public void Rollback()
    {
        _dbTransaction.Rollback();
    }
}