using Cloth.Application.Interfaces;
using Cloth.Application.Interfaces.Repositories;
using Cloth.Persistence.Ef.Context;

namespace Cloth.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClothInventoryDbContext _dbContext;
    public IClothRepository Cloths { get; }
    public ISizeRepository Sizes { get; }
    public IGroupRepository Groups { get; }
    public IBasketRepository Baskets { get; }
    public IBasketLineRepository BasketLines { get; }
    public IOrderRepository Orders { get; }
    public IClothSizeRepository ClothSizes { get; }

    public UnitOfWork(ClothInventoryDbContext dbContext, IClothRepository clothRepository,
        ISizeRepository sizes, IOrderRepository orders, IGroupRepository groups, IBasketRepository baskets, IBasketLineRepository basketLines, IClothSizeRepository clothSizes)
    {
        _dbContext = dbContext;
        Cloths = clothRepository;
        Sizes = sizes;
        Orders = orders;
        Groups = groups;
        Baskets = baskets;
        BasketLines = basketLines;
        ClothSizes = clothSizes;
    }

    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public void Rollback()
    {
        throw new NotImplementedException();
    }
}