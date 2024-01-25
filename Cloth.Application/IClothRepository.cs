namespace Cloth.Application;

using Cloth.Domain.Entities;
using System.Collections.Generic;

public interface IClothRepository
{
    Task<IEnumerable<Cloth>> GetAllCloths();
}

