namespace Cloth.Application.Interfaces.Repositories;

using Cloth.Domain.Entities;
using global::Persistence.Abstractions.Interfaces;
using System.Collections.Generic;

public interface IClothRepository : IGenericRepository<Cloth>
{
    Task<IEnumerable<Cloth>> GetAllCloths();

    Task<Cloth> GetClothById(Guid clothId);
}