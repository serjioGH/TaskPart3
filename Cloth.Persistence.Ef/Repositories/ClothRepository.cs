namespace Cloth.Persistence.Ef.Repositories;

using Cloth.Application.Interfaces;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.Ef.Context;
using global::Persistence.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
public class ClothRepository : GenericRepository<Cloth>, IClothRepository
{
    protected readonly ClothInventoryDbContext _dbContext;
    public ClothRepository(ClothInventoryDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Cloth>> GetAllCloths()
    {
        var result = await _dbContext.Cloths
            .Include(p => p.Brand)
            .Include(p => p.ClothSizes).ThenInclude(cs => cs.Size)
            .Include(p => p.ClothGroups).ThenInclude(cg => cg.Group)
            .ToListAsync();

        return result;
    }

    public async Task<Cloth> GetClothById(Guid clothId)
    {
        var result = await _dbContext.Cloths
        .Where(p => p.Id == clothId)
        .Include(p => p.Brand)
        .Include(p => p.ClothGroups).ThenInclude(cg => cg.Group)
        .Include(p => p.ClothSizes).ThenInclude(cs => cs.Size)
        .FirstOrDefaultAsync();

        if (result == null)
        {
            throw new ItemNotFoundException($"Cloth: {clothId} not found.");
        }

        return result;
    }
}