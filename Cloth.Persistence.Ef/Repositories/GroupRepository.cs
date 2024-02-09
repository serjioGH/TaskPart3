using Cloth.Application.Interfaces;
using Cloth.Domain.Entities;
using Cloth.Persistence.Ef.Context;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloth.Persistence.Ef.Repositories;

internal class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ClothInventoryDbContext dbContext) : base(dbContext)
    {
    }

    public Task<IEnumerable<Group>> GetAllCloths()
    {
        throw new NotImplementedException();
    }

    public Task<Group> GetClothById(Guid groupId)
    {
        throw new NotImplementedException();
    }
}
