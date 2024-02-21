using AutoMapper;
using Cloth.Application.Interfaces;
using Cloth.Application.Models.Dto;
using Cloth.Domain.Entities;
using MediatR;

namespace Cloth.Application.Features.Commands.Cloths.ClothUpdate;

public class ClothUpdateCommandHandler : IRequestHandler<ClothUpdateCommand, UpdateClothDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ClothUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateClothDto> Handle(ClothUpdateCommand command, CancellationToken cancellationToken)
    {
        var cloth = await _unitOfWork.Cloths.GetClothById(command.Id);

        cloth.Title = command.Title;
        cloth.Description = command.Description;
        cloth.Price = command.Price;
        cloth.BrandId = command.BrandId;

        foreach (var newSize in command.Sizes)
        {
            var existingSize = cloth.ClothSizes.SingleOrDefault(p => p.SizeId == newSize.SizeId);
            if (existingSize != null)
            {
                existingSize.QuantityInStock = newSize.Quantity;
            }
            else
            {
                cloth.ClothSizes.Add(new ClothSize
                {
                    SizeId = newSize.SizeId,
                    QuantityInStock = newSize.Quantity
                });
            }
        }

        foreach (var groups in command.Groups)
        {
            var currentGroup = cloth.ClothGroups.SingleOrDefault(p => p.GroupId == groups.GroupId);
            if (currentGroup == null)
            {
                cloth.ClothGroups.Add(new ClothGroup
                {
                    GroupId = groups.GroupId
                });
            }
        }

        _unitOfWork.Save();

        var updatedProductDto = _mapper.Map<UpdateClothDto>(cloth);

        return updatedProductDto;
    }
}