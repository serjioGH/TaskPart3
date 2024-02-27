using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Persistence.PostgreSQL.Context;
using Persistence.Abstractions.Repositories;

namespace Cloth.Persistence.PostgreSQL.Repositories;

internal class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ClothInventoryDbContext dbContext) : base(dbContext)
    {
    }
}