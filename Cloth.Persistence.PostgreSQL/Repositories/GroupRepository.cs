using Cloth.Application.Interfaces.Repositories;
using Cloth.Domain.Entities;
using Cloth.Persistence.PostgreSQL.Context;
using Persistence.Abstractions;
using System.Data;

namespace Cloth.Persistence.PostgreSQL.Repositories;

internal class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ClothInventoryDbContext dbContext, IDbConnection dbConnection) : base(dbContext, dbConnection)
    {
    }
}