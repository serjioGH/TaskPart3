using Cloth.Application.Interfaces;
using Cloth.Persistence.Ef.Context;
using Microsoft.EntityFrameworkCore;

namespace Cloth.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClothInventoryDbContext _dbContext;
    public IClothRepository Cloths { get; }
    public ISizeRepository Sizes { get; }

    public IGroupRepository Groups { get; }

    public IOrderRepository Orders { get; }
    public UnitOfWork(ClothInventoryDbContext dbContext, IClothRepository clothRepository,
        ISizeRepository sizes, IOrderRepository orders, IGroupRepository groups)
    {
        _dbContext = dbContext;
        Cloths = clothRepository;
        Sizes = sizes;
        Orders = orders;
        Groups = groups;
    }

    public int Save()
    {
        return _dbContext.SaveChanges();
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
