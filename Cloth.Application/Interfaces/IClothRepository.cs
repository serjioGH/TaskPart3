namespace Cloth.Application.Interfaces;

using Cloth.Domain.Entities;
using Persistence.Abstractions.Interfaces;
using System.Collections.Generic;

public interface IClothRepository : IGenericRepository<Cloth>
{
    Task<IEnumerable<Cloth>> GetAllCloths();
    Task<Cloth> GetClothById(Guid clothId);
}

