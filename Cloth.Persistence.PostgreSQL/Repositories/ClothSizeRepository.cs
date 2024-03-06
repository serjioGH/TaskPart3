using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Domain.Exceptions;
using Cloth.Persistence.PostgreSQL.Constants.DapperQueries;
using Cloth.Persistence.PostgreSQL.Context;
using Dapper;
using Persistence.Abstractions;
using System.Data;

namespace Cloth.Persistence.PostgreSQL.Repositories;

public class ClothSizeRepository : GenericRepository<ClothSize>, IClothSizeRepository
{
    protected readonly ClothInventoryDbContext _dbContext;
    private readonly IDbConnection _dbConnection;

    public ClothSizeRepository(ClothInventoryDbContext dbContext, IDbConnection dbConnection) : base(dbContext, dbConnection)
    {
        _dbContext = dbContext;
        _dbConnection = dbConnection;
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
        try
        {
            var result = await _dbConnection.QuerySingleAsync<ClothSize>(
                ReadFromDbConstants.ClothSizeConstants.GetByCompositeKeyQuery,
                new { ClothId = clothId, SizeId = sizeId }
            );

            return result;
        }
        catch (Exception ex)
        {
            throw new ItemNotFoundException($"ClothSize not found with these ClothId and SizeId.", ex);
        }
    }
}