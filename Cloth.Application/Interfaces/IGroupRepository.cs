using Cloth.Domain.Entities;
using Persistence.Abstractions.Interfaces;

namespace Cloth.Application.Interfaces;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<IEnumerable<Group>> GetAllCloths();
    Task<Group> GetClothById(Guid groupId);
}
