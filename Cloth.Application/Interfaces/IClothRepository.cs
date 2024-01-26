namespace Cloth.Application.Interfaces;

using Cloth.Domain.Entities;
using System.Collections.Generic;

public interface IClothRepository
{
    Task<IEnumerable<Cloth>> GetAllCloths();
}

