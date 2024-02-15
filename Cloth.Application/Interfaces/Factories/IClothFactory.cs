namespace Cloth.Application.Interfaces.Factories;

using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Domain.Entities;

public interface IClothFactory
{
    Cloth CreateCloth(ClothCreateCommand command);
}