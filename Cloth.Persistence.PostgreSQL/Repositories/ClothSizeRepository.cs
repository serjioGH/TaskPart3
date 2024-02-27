namespace Cloth.Persistence.PostgreSQL.Repositories;

using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.PostgreSQL.Context;
using global::Persistence.Abstractions.Repositories;
using System;
using System.Threading.Tasks;

public class ClothSizeRepository : GenericRepository<ClothSize>, IClothSizeRepository
{
    protected readonly ClothInventoryDbContext _dbContext;

    public ClothSizeRepository(ClothInventoryDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteByCompositKey(Guid clothId, Guid sizeId)
    {
        var clothSize = await _dbContext.Set<ClothSize>().FindAsync(clothId, sizeId);
        if (clothSize == null)
        {
            throw new ItemNotFoundException($"ClothSize not found with these ClothId and SizeId.");
        }
        _dbContext.ClothSizes.Remove(clothSize);
    }

    public async Task<ClothSize> GetByCompositKey(Guid clothId, Guid sizeId)
    {
        var productSize = await _dbContext.Set<ClothSize>().FindAsync(clothId, sizeId);

        if (productSize == null)
        {
            throw new ItemNotFoundException($"ClothSize not found with these ClothId and SizeId.");
        }

        return productSize;
    }
}