namespace Cloth.Application.Interfaces.Repositories;

using Cloth.Domain.Entities;
using global::Persistence.Abstractions.Interfaces;
using System;
using System.Threading.Tasks;

public interface IClothSizeRepository : IGenericRepository<ClothSize>
{
    Task<ClothSize> GetByCompositKey(Guid clothId, Guid sizeId);

    Task DeleteByCompositKey(Guid clothId, Guid sizeId);
}