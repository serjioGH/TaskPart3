using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Persistence.Ef.Context;
using Persistence.Abstractions.Repositories;

namespace Cloth.Persistence.Ef.Repositories;

internal class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ClothInventoryDbContext dbContext) : base(dbContext)
    {
    }
}