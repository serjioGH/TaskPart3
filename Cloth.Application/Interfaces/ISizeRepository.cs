using Cloth.Domain.Entities;
using Persistence.Abstractions.Interfaces;

namespace Cloth.Application.Interfaces;

public interface ISizeRepository : IGenericRepository<Size>
{
    Task<IEnumerable<Size>> GetAllCloths();
    Task<Size> GetClothById(Guid sizeId);
}
