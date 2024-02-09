using Cloth.Application.Features.Commands.Cloth.ClothCreate;
using Cloth.Application.Interfaces.Factories;

namespace Cloth.Infrastructure.Factories;
using Cloth.Domain.Entities;
internal class ClothFactory : IClothFactory
{
    public Cloth CreateCloth(ClothCreateCommand command)
    {
        var cloth = new Cloth
        {
            Title = command.Title,
            Description = command.Description,
            Price = command.Price,
            BrandId = command.BrandId,
            ClothSizes = command.Sizes.Select(size => new ClothSize
            {
                SizeId = size.SizeId,
                QuantityInStock = size.Quantity
            }).ToList(),
            ClothGroups = command.Groups.Select(group => new ClothGroup
            {
                GroupId = group.GroupId
            }).ToList()
        };

        return cloth;
    }
}
