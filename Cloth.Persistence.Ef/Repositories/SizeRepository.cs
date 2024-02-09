using Cloth.Application.Interfaces;
using Cloth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Interfaces;
using Persistence.Abstractions.Repositories;

namespace Cloth.Persistence.Ef.Repositories;

public class SizeRepository : GenericRepository<Size>, ISizeRepository
{
    public SizeRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public Task<IEnumerable<Size>> GetAllCloths()
    {
        throw new NotImplementedException();
    }

    public Task<Size> GetClothById(Guid sizeId)
    {
        throw new NotImplementedException();
    }
}
